
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Color color;
    public GameObject square;
    public SpriteRenderer sprite;
    public Slider slider;
    //audio
    public AudioSource audioSource;
    public AudioClip button;
    public AudioClip slip;

    // Start is called before the first frame update
    void Start()
    {
        // Properly get the GameObject and components
     
        sprite = square.GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Directly use the slider value to update the z-rotation
        Vector3 currentEulerAngles = square.transform.eulerAngles;
        currentEulerAngles.z = slider.value;
        square.transform.eulerAngles = currentEulerAngles;

        // Debug to monitor the rotation changes
        Debug.Log("Current Z Rotation: " + currentEulerAngles.z);
    }

    public void Clicking()
    {
        // Change color randomly on some event (e.g., button click)
        color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        sprite.color = color;
        //audio
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(button);

        }

    }
    public void Sound() {

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(slip);

        }


    }
}
