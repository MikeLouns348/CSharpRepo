using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//swaps the materials on an object rapidly
public class BombFlash : MonoBehaviour
{
    public Material color1;
    public Material color2;

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine("flashOff");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator flashOff()
    {
        yield return new WaitForSeconds(0.1f);
        MeshRenderer my_renderer = GetComponent<MeshRenderer>();
        my_renderer.material = color1;
        StartCoroutine("flashOn");

    }

    IEnumerator flashOn()
    {
        yield return new WaitForSeconds(0.1f);
        MeshRenderer my_renderer = GetComponent<MeshRenderer>();
        my_renderer.material = color2;
        StartCoroutine("flashOff");

    }
}