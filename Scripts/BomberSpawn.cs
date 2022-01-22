using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//spawns the bombers
public class BomberSpawn : MonoBehaviour
{

    public Transform enemy;
    public int spawnTime;
    
    void Start()
    {
        StartCoroutine("bomberSpawn");
    }


    
    void Update()
    {

    }

    IEnumerator bomberSpawn()
    {
        yield return new WaitForSeconds(spawnTime);

        Instantiate(enemy, transform.position, Quaternion.Euler(new Vector3(90, 0, -180)));
        StartCoroutine("bomberSpawn");
    }
}