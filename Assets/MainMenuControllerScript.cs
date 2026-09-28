using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("UIandHazardsScene");
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

}