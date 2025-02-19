using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //Player Fish
    public GameObject playerFish;
    public Vector3 mousePos;
    public float playerSpeed = 5f;
    public int value;
    //text
    public GameObject txt;
    TextMeshProUGUI text;
    //targets learned from week 6
    public GameObject npcFish;
    public int howmanyFish = 15;
    public List<GameObject> targetFish;
    //Npc fish variables
    // int worth;
    public GameObject fish_txt;
    TextMeshProUGUI fish_text;

    // Start is called before the first frame update
    void Start()
    {
        ShowValue();
        spawnController();
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
        } Maybe use a bigger if() make it work until it is not same as the position of it?????
        */
    }
    void spawnController()
    {
        targetFish = new List<GameObject>();

        for (int i = 0; i < howmanyFish; i++)
        {
            GameObject newTarget = Instantiate(npcFish);
            newTarget.transform.position = Random.insideUnitCircle * 10;

            // Generate a random number between 5 and 15
            int randomValue = Random.Range(5, 16); // max-16 is 15 in Unity's Random.Range for ints 

            // Assuming newTarget has a TextMeshPro component or a custom script that handles text
            //var fishTextComponent = newTarget.GetComponentInChildren<TextMeshPro>(); // Or another text component but might not allowed to use
            fish_text = fish_txt.GetComponent<TextMeshProUGUI>();
            if (fish_text != null) //checking if it exist
            {
                fish_text.text = randomValue.ToString();
            }

            // Add the new fish to the list
            targetFish.Add(newTarget);
        }
    }
    void ShowValue()
    {
        text = txt.GetComponent<TextMeshProUGUI>();
        text.text = value.ToString();
    }

}
