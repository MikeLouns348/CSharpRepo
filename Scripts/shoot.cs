using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
	//shoots and creates a delay to prevent shooting too fast
	public Transform bullet;
	public int shootTimer = 1;
	public float shootDelay;

	void Start()
	{
		

	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) && shootTimer > 0)
		{
			Shoot();
			shootTimer--;
			StartCoroutine("shootTime");
		}
	}

	void Shoot()
	{
		Instantiate(bullet, transform.position, Quaternion.identity);



	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
			Destroy(gameObject);

	}

	IEnumerator shootTime()
	{
		yield return new WaitForSeconds(shootDelay);
			shootTimer = 1;
		
	}


}

