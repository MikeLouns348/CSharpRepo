using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    //a visual efect to make the player ship blink to indicate invulnerability
    public Renderer rend;
    public int activeCount;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("flashOff");
    }

    void Update()
    {

    }

    IEnumerator flashOff()
    {
        yield return new WaitForSeconds(0.2f);
        rend.enabled = false;
        StartCoroutine("flashOn");

    }

    IEnumerator flashOn()
    {
        yield return new WaitForSeconds(0.2f);
        rend.enabled = true;
        activeCount++;
        if (activeCount < 4)
        {
            StartCoroutine("flashOff");
        }

    }
}