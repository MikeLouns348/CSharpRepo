using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
     //a simple script for a scene loading button
    public int x;

    public void Awake()
    {
        
    }
    public void ButtonClicky()
    {

        SceneManager.LoadScene(x);
    }

    
}

