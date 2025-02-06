using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject txt;
    TextMeshProUGUI text;
     Slider slider;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        text = txt.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        slider.value = t % slider.maxValue;
        text.text = ((int)(slider.value*100)).ToString();
        //if (slider.value > 1)
        //{
        //    slider.value = 0;
        //}
    }
}
