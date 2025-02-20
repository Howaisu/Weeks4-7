using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Range(0, 2)] public float location;

    // Start is called before the first frame update
    void Start()
    {
        location = 1;
    }

    // Update is called once per frame
    void Update()
    {
        location = Mathf.Clamp(location, 0, 2);
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            location--;
            Debug.Log(location);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            location++;
            Debug.Log(location);
        }
        Vector2 pos = transform.position;
        if (location == 0)
        { 
            pos.y = 3;
        }
        else if (location == 1)
        {
            pos.y = 0;
        }
        else if (location == 2)
        {
            pos.y = -3;
        }
        transform.position = pos;   


    }
}
