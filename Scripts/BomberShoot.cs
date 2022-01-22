using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//logic for bomber shooting
public class BomberShoot : MonoBehaviour
{
    public Transform bomb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator Shoot()
    {
       
        yield return new WaitForSeconds(Random.Range(3,5));
           Instantiate(bomb, transform.position, Quaternion.identity);
            StartCoroutine("Shoot");
        
        

    }
}
