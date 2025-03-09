using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Load a scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Exit the game
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit(); // This will close the game when built
    }
}
