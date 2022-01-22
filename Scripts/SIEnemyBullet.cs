using UnityEngine;
using System.Collections;

public class SIEnemyBullet : MonoBehaviour

{

	//exposes controls speed and time before self destruct
	public int speed = 100;
	public int destroyTime = 3;


	
	void Start () {
	
	}

	//gives the gameObject speed and direction
	void Update () {
		Destroy(gameObject, destroyTime);
		transform.Translate(Vector3.down * Time.deltaTime *speed);
		

	}

    private void OnTriggerEnter(Collider other)
    {
     //prevents the object from destroying multiple barrier bits and the ship in one bullet.
        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Player")
        {
			Destroy(gameObject);
		}
    }

}

