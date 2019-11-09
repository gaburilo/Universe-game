using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour {

    public bool isStart;
    public bool isQuit;

    private void OnMouseUp()
    {
        if(isStart)
        {
            
            SceneManager.LoadScene(0);
        }

        if(isQuit)
        {
            Application.Quit();
        }
    }
}
