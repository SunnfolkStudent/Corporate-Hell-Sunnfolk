using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameBackToMenu : MonoBehaviour
{
    

    public void GameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

}