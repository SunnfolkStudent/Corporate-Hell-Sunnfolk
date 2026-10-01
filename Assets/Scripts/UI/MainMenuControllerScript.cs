using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

}