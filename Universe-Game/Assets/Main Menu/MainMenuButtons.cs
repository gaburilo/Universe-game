﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour {
    public void ButtonStart()
    {
        SceneManager.LoadScene(2);
           
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

}
