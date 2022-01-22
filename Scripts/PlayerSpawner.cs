using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerShip;
    //Creates the barrier at the beginning of the scene load
    void Start()
    {
        //Debug.Log("Hello world");
        StartCoroutine("playerSpawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    //creates a 2 second pause between death and spawn
    IEnumerator playerSpawn()
    {
        yield return new WaitForSeconds(2);
        Instantiate(playerShip, transform.position, Quaternion.Euler(new Vector3(90, -180, 0))); 
    }
}