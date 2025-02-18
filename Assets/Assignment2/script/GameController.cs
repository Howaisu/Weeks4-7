using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerFish;
    // Start is called before the first frame update
    void Start()
    {
        //hello world
    }

    // Update is called once per frame
    void Update()
    {
        spinMaker();
    }

    // Method to make the circle face the mouse position
    public void spinMaker()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction vector from the circle to the mouse
        Vector3 direction = mousePos - transform.position;

        // Find the angle (in radians) and convert it to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the circle (only on the z-axis)
        playerFish.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
