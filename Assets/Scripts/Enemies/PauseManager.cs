using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;


public class PauseManager : MonoBehaviour
{


    public static bool paused = false;
    
    public GameObject PauseMenu;



    // Use this for initialization

    void Start()

    {



    }



    // Update is called once per frame

    void Update()

    {



        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            hideOrShow();
        }
            


    }



    public void hideOrShow()

    {

        if (PauseMenu.activeInHierarchy)
        {
            PauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1;

        }
        else
        {
            PauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }

    }



    public void restart()

    {

        Application.LoadLevel(Application.loadedLevel);

    }



    public void quit()

    {

        //Application.LoadLevel("nameOfMainMenu");

        Application.Quit();

    }

}