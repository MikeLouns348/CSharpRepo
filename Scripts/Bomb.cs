using UnityEngine;
using System.Collections;

//logic for the bomb
public class Bomb : MonoBehaviour

{
	public int speed = 100;


	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		Destroy(gameObject, 3);
		transform.Translate(Vector3.down * Time.deltaTime *speed);
		

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Player")
        {
			Destroy(gameObject);
		}
    }

}

