using UnityEngine;
using System.Collections;


public class EnemyShipMovementLeft : MonoBehaviour {


	//controls movement for enemy ships that begin by moving to the left

	public GM GMCaller;
	public Vector3 lastPos;
	public float totalDistance;
	public float travelDistanceInput;
	public Transform explosion;
	public int points;

	
	void Start(){
		GMCaller = GameObject.FindObjectOfType<GM>();
		lastPos = transform.position; 
		StartCoroutine("moveleft");
		

	}

    void Update()
    {
		//gets the global time increment from the GM to determine time between moves.
		GMCaller.timeToMove = GMCaller.time;
		float distance = Vector3.Distance(lastPos, transform.position);
		totalDistance += distance;
		lastPos = transform.position;
		//Debug.Log("total distance = " + totalDistance);
        if (totalDistance > travelDistanceInput + 10)
        {
			
			totalDistance = 0;
        }
		

	}

	//pulls global variabls from GM to create the illusion of old school space invaders where they tick over instead of smooth transition between points. 
	IEnumerator moveright()
	{
		yield return new WaitForSeconds(GMCaller.timeToMove);
		transform.Translate(GMCaller.distancePerMove, 0, 0);

		//calculates teh distane traveled so that all ships transisition downward and change directions at the same time
		if (totalDistance >= travelDistanceInput)
			transform.Translate(0, 0, -30);
		if (totalDistance >= travelDistanceInput)
			StartCoroutine("moveleft");
			
		else
			StartCoroutine("moveright");
			
		

	}
	IEnumerator moveleft()
	{
		yield return new WaitForSeconds(GMCaller.timeToMove);
		transform.Translate(-GMCaller.distancePerMove, 0, 0);
		if (totalDistance >= travelDistanceInput)
			transform.Translate(0, 0, -30);
		if (totalDistance >= travelDistanceInput)
			StartCoroutine("moveright");
		else
			StartCoroutine("moveleft");
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
		GMCaller.score += points;
		GMCaller.enemiesDefeated++;
		Destroy(gameObject);
	}
}
