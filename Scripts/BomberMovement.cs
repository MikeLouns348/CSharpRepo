using UnityEngine;
using System.Collections;


public class BomberMovement : MonoBehaviour {

	
	//public float timeToMove;
	//public float distancePerMove;
	
	public GM GMCaller;

	public Transform explosion;
	public int points;
	public int speed;

	
	void Start(){
		GMCaller = GameObject.FindObjectOfType<GM>();

		

	}

    void Update()
    {
		Destroy(gameObject, 45);
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		

	}

	
	public void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Shot Connected");
		if (other.gameObject.name == "Bullet(Clone)")
		{
			
			BlowUp();
		}
	}

	void BlowUp()
	{
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
		GMCaller.score += points;
		GMCaller.enemiesDefeated++;
	}
	
}
