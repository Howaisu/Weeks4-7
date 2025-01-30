using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// This code is for the rotation of clock
/// </summary>
public class CodingGym_Clock : MonoBehaviour
{
    [SerializeField] float timeSpeed;
    public TextMeshProUGUI time;
    [SerializeField] int Hours;
    float counter;
    public bool hourPassed;
    //Audio
    public AudioSource audioSource;
    public AudioClip chime;

    // Start is called before the first frame update
    void Start()
    {
        Hours = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotating = transform.eulerAngles;
        rotating.z -= timeSpeed;
        transform.eulerAngles = rotating;


        //check the hour
        // time.text = ("Debug" + Mathf.Abs(rotating.z)%30);
        //int counter = Mathf.FloorToInt(Mathf.Abs(rotating.z) % 30);

        //if (Mathf.Abs(rotating.z) % 30 == 0) {
        // //  counter++;
        //    hourPassed = true;
        //    Hours++;

        //}
        // int a = Mathf.FloorToInt(rotating.z);
        //int counter =  Mathf.Abs(a) % 30;


        //  counter = Mathf.Round(counter + timeSpeed);
        counter += timeSpeed;
        if ((30*timeSpeed) % counter   == 0)
        {
            counter++;
            // hourPassed = true;
            playSound();
            Hours++;
        }
            //else
            //{ 
            //    hourPassed = false;
            //}


            if (Hours >= 12)
            {
                Hours = 0;
            }

time.text = ("The time is:"+ Hours + " \n and ("+ counter + " )");
        
       
    }//
    //Sound
    void playSound()
    {
        if (hourPassed = true)
        {
            if (audioSource.isPlaying == false)
            {
                for (int a = 0; a < Hours; a++)
                {
                    // audioSource.Play();
                    audioSource.PlayOneShot(chime);
                }
            }
        }

    }
}
