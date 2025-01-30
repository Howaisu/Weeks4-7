using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOff : MonoBehaviour
{


    //
    public GameObject go;
    public SpriteRenderer sr;
    public OnAndOff script;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            sr.enabled = false;
            //
            go.SetActive(false);
                //
            //script.enabled = false
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            sr.enabled = true;
            //script.enabled = true;
            go.SetActive(true);

        }
    }
}
