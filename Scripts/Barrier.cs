using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls logic for destruction of each barrier bit.
public class Barrier : MonoBehaviour{

    public Transform explosion;
    // Causes the portion of the barrier contacted by an enemy or friendly bullet to explode.
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("we hit");
        if(other.gameObject.tag == "bullet")
        {
            BlowUp();
          
        }
        void BlowUp()
        {
            Instantiate(explosion, transform.position, Quaternion.identity);           
            Destroy(gameObject);
        }
    }

}



