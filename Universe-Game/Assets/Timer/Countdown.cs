using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f; //can change to whatever number you want it to start at

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

        //changes to main menu scene
        if (currentTime == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
