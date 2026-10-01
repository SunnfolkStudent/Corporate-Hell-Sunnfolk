using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneManager : MonoBehaviour
{
    public void goToCutscene()
    {
        SceneManager.LoadScene("CutScene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            goToCutscene();
        }
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    
}
