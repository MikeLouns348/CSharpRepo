using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDestroy : MonoBehaviour
{
    public bool killCanvas = false;
    // This object is labeled DoNotDestroy.  This destroys the object on game over
    void Awake()
    {
       

        DontDestroyOnLoad(this.gameObject);
        
    }
    private void Update()
    {
        if (killCanvas == true)
        {
            Destroy(this.gameObject);
        }
    }


}
