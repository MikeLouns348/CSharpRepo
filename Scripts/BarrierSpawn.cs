using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns the barriers
public class BarrierSpawn : MonoBehaviour
{
    public Transform barrier;
    //Creates the barrier at the beginning of the scene load
    void Awake()
    {
        Instantiate(barrier, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
