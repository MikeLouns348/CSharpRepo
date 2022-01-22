using UnityEngine;
using System.Collections;

public class SIBullet : MonoBehaviour

{
	public int speed = 100;


	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		Destroy(gameObject, 3);
		transform.Translate(Vector3.up * Time.deltaTime *speed);
		

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Enemy")
        {
			Destroy(gameObject);
		}
    }

}

