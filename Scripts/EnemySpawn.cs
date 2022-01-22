using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform enemy;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(enemy, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
