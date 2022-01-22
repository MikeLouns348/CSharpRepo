using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float moveSpeed = 100;
	public GameObject Sparks;
	public GameObject Sparks1;
	public int activeCount = 0;
	
	
	public GM GMCaller;


	void Start(){

		//finds the game master to call on global variables like time, score, and lives.
		GMCaller = GameObject.FindObjectOfType<GM>();
		
		StartCoroutine("invincible");
	}
	
	void Update () 
	{
	
	//controles player position and checks for position, to prevent movement beyond the hard coded limit (this varible should be exposed)	
		if (transform.position.x > 111 && Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
		}
		if (transform.position.x < 500 && Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
		}
				
	}
	//looks for collision with specific objects by name.
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.name == "EnemyBullet(Clone)" || other.gameObject.name == "BigEnemyBullet(Clone)")
			BlowUp();
	}

	//creates effects, reduces lives and checks for lose condition lives <= 0
	void BlowUp()
	{
		Instantiate(Sparks, transform.position, Quaternion.identity);
		Instantiate(Sparks1, transform.position, Quaternion.identity);
		GMCaller.life--;
		activeCount = 0;
		if (GMCaller.life > 0)
		{
			GameObject spawn = GameObject.Find("PlayerSpawner");
			spawn.GetComponent<PlayerSpawner>().StartCoroutine("playerSpawn");
		}
		else if (GMCaller.life <= 0)
		{
			GMCaller.GetComponent<GM>().StartCoroutine("endGame");
		}
		Destroy(gameObject);
	}

	//The player prefab gets spawned on a game layer by itself to prevent game object interaction, and after 2 seconds is broght to the games main layer. 
	IEnumerator invincible()
	{
		yield return new WaitForSeconds(2);
		gameObject.layer = 0;
	}


}