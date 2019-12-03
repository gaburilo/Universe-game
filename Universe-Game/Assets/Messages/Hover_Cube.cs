using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hover_Cube : MonoBehaviour
{

    public string myString; //text being displayed
    public Text myText; //reference to text
    public float fadeTime; //fading in/out text
    public bool displayinfo; //determines whether we will fade text or not

    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>(); 
        myText.color = Color.clear;
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
        
        /*if (Input.GetKeyDown (KeyCode.Escape))
        {
            Screen.lockCursor = false;
        }*/
    }

    void OnMouseOver()
    {
        displayinfo = true;
    }

    void OnMouseExit()
    {
        displayinfo = false;
    }
    void FadeText()
    {
        if (displayinfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime* Time.deltaTime);
        }
    }
}
