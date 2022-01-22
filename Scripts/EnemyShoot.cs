using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform enemyBullet;
    public int fireRangeBtm = 5;
    public int fireRangeTop = 8;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //Prevents the pre-loaded non-visible enemies from shooting until they become visible to the player
    IEnumerator Shoot()
    {
        int waitTime = Random.Range(5, 10);
        yield return new WaitForSeconds(waitTime);
        if (transform.position.y < 290)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            StartCoroutine("Shoot");
        }
        else
        {
            StartCoroutine("Shoot");
        }

    }
}
