// Pause Button code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;

    bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }

    public void PauseGame()
    {
        gamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        gamePaused = false;

        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }
}
