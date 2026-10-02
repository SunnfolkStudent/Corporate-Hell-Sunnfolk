using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneManager : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip creditMusic;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
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

    public void cutSceneMusic()
    {
        _audioSource.PlayOneShot(creditMusic);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    
}
