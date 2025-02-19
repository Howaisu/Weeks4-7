using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //Player Fish
    public GameObject playerFish;
    public GameObject secondLayer;
    public Vector3 mousePos;
    public float playerSpeed = 5f;
    public int value;
    //text
    public GameObject txt;
    public GameObject scoreboard;
    TextMeshProUGUI score;
    TextMeshProUGUI text;
    //targets learned from week 6
    public GameObject npcFish;
    public int howmanyFish = 15;
    public List<GameObject> targetFish;
    //Npc fish variables
    // int worth;
    public List<int> npcValues;
    public GameObject fish_txt;
    TextMeshProUGUI fish_text;
    //NPC momvements
    public List<Vector2> npcDirections;  // Store movement direction for each npcFish
    public float npcSpeed = 2f;  // Speed of npcFish
                                 //UI canvas - setting
    public GameObject Canvas;
    //UI control values
    public Slider fishAmount;
    public Slider fishSpeed;
    public TextMeshProUGUI amountCount;
    public TextMeshProUGUI speedCount;

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
        CheckCollisions();
        MoveNpcFish();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasOnOff();
        }
        //UI
        amountController();

    }

    // Method to make the circle face the mouse position
    public void spinMaker()
    {
       
        // Calculate the direction vector from the circle to the mouse
        Vector3 direction = mousePos - transform.position;

        //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Mathf.Rad2Deg.html
        // Find the angle (in radians) and convert it to degrees(circle)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        // Set the rotation angle to the circle or use transform.eulerAngle=rotation
        secondLayer.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Move()
    {
        // transfer mouse position to world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; //lock the z (2D)

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

        //Alright, does not a serious problem, give it up for now
        */
    }
    void spawnController()
    {
        targetFish = new List<GameObject>();
        npcValues = new List<int>();
        npcDirections = new List<Vector2>();  // Initialize direction storage

        for (int i = 0; i < howmanyFish; i++)
        {
            GameObject newTarget = Instantiate(npcFish);
            newTarget.transform.position = Random.insideUnitCircle * 10; // Can adjust for world space limits.

            // Generate a random number between 5 and 15
            int npcValue = Random.Range(5, 16);

            // Store the value in the npcValues list
            npcValues.Add(npcValue);

            // Assign text value to NPC fish UI
            TextMeshProUGUI npcText = newTarget.GetComponentInChildren<TextMeshProUGUI>();
            if (npcText != null)
            {
                npcText.text = npcValue.ToString();
            }

            // Add the new fish to the list
            targetFish.Add(newTarget);

            // Assign a random movement direction
            Vector2 randomDirection = Random.insideUnitCircle.normalized; // Random (x,y) direction
            npcDirections.Add(randomDirection); // Store movement direction

        }
    }


    // Move the NPC fish in the assigned direction
    void MoveNpcFish()
    {
        for (int i = 0; i < targetFish.Count; i++)
        {
            if (targetFish[i] != null) // Ensure fish exists
            {
                // Move each NPC fish in its assigned random direction
                targetFish[i].transform.position += (Vector3)npcDirections[i] * npcSpeed * Time.deltaTime;

                // Check if the fish hits the boundary and bounce it back
                if (Mathf.Abs(targetFish[i].transform.position.x) > 10f || Mathf.Abs(targetFish[i].transform.position.y) > 10f)
                {
                    npcDirections[i] = -npcDirections[i]; // Reverse direction
                }
            }
        }
    }


    // Check if NPC hits world boundaries, then bounce back
    //void CheckBounds()
    //{
    //    if (Mathf.Abs(transform.position.x) > worldBoundary || Mathf.Abs(transform.position.y) > worldBoundary)
    //    {
    //        moveDirection = -moveDirection; // Reverse direction upon hitting the boundary
    //    }
    //}

    void ShowValue()
        {
            text = txt.GetComponent<TextMeshProUGUI>();
            score = scoreboard.GetComponent<TextMeshProUGUI>();
            score.text = value.ToString();
            text.text = value.ToString();

        }


    void CheckCollisions()
    {
        for (int i = targetFish.Count - 1; i >= 0; i--) // Loop from last to first
        {
            GameObject npc = targetFish[i];
            float distance = Vector3.Distance(playerFish.transform.position, npc.transform.position);

            if (distance < 0.5f) // Collision threshold
            {
                // Debugging logs to check mapping
            

                // Get the corresponding npcValue from npcValues list
                int npcValue = npcValues[i];

                // Add it to playerFish's value
                value += npcValue;
                ShowValue(); // Update the fish's UI text

                // Remove the fish and its value from their respective lists
                targetFish.RemoveAt(i);
                npcValues.RemoveAt(i);
                Destroy(npc);

            
            }
        }
    }

    void CanvasOnOff() 
    {
        if (Canvas != null)
        {
            Canvas.SetActive(!Canvas.activeSelf); // Turn on and off Canvas visibility
        }

    }

    void amountController()
    {
        // Set the variables to the slider values (allows user to modify sliders freely)
        howmanyFish = Mathf.RoundToInt(fishAmount.value);
        npcSpeed = fishSpeed.value;

        // Update text displays to match the current values
        amountCount.text = howmanyFish.ToString();
        speedCount.text = npcSpeed.ToString();
    }

    public void SpawnNPCs()//The button
    {
        // Clear existing NPCs before spawning new ones
        for (int i = targetFish.Count - 1; i >= 0; i--)
        {
            Destroy(targetFish[i]);
        }

        targetFish.Clear();
        npcValues.Clear();
        npcDirections.Clear();

        // Spawn new NPCs
        spawnController();
    }
    public void ResSet()
    {
        //value to beginning

        value = 20;
        ShowValue();

    }


}
