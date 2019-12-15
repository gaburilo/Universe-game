using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {

        //counts down by 1
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0"); //helps countdown whole numbers
        
        //makes timer stop at 0
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
