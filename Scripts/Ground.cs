using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GM GMCaller;
    // Start is called before the first frame update
    void Start()
    {
        //finds the game master to initiate the game over coroutine
        GMCaller = GameObject.FindObjectOfType<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //ends the game if an enemy ship touches down.
        if (other.gameObject.tag == "Enemy")
        {
            GMCaller.gameOver.enabled = true;
            GMCaller.GetComponent<GM>().StartCoroutine("endGame");

        }
    }
}
