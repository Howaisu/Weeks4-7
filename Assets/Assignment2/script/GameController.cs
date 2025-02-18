using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Player Fish
    public GameObject playerFish;
    public Vector3 mousePos;
    public float playerSpeed = 5f;
    public int value;
    //targets learned from week 6
    public GameObject npcFish;
    public int howmanyFish = 15;
    public List<GameObject> targetFish;
    // Start is called before the first frame update
    void Start()
    {
        //hello world
        targetFish = new List<GameObject>();
        for (int i = 0; i < howmanyFish; i++)
        {
            GameObject newTarget = Instantiate(npcFish);
            newTarget.transform.position = Random.insideUnitCircle * 5;

           

            targetFish.Add(newTarget);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        // Get the mouse position in world space (put it here because it may re-use multiple times
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //head rotation
        spinMaker();
        //moving
        Move();
    }

    // Method to make the circle face the mouse position
    public void spinMaker()
    {
       
        // Calculate the direction vector from the circle to the mouse
        Vector3 direction = mousePos - transform.position;

        // Find the angle (in radians) and convert it to degrees(circle)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        // Set the rotation angle to the circle or use transform.eulerAngle=rotation
        playerFish.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Move()
    {
        // transfer mouse position to world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; //lock the z

        // get the direction from fish to mouse
        Vector3 direction = (mousePos - playerFish.transform.position).normalized;

        // Move playerFish in the direction of the mouse
        playerFish.transform.position += direction * playerSpeed * Time.deltaTime;

        //bug fixing
        /*
        if (playerFish.transform.position == mousePos)
        { 
            playerSpeed = 0; //not working, just leave like this for now
        }
        */
    }

}
