using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;

    public static bool IsPaused { get; private set; } = false;

    void Start()
    {
        // Hide cursor and pause UI on game start
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseUI != null)
            pauseUI.SetActive(true);

        Time.timeScale = 0f;
        IsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioListener.pause = true; // mute audio
    }

    public void ResumeGame()
    {
        if (pauseUI != null)
            pauseUI.SetActive(false);

        Time.timeScale = 1f;
        IsPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        AudioListener.pause = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = false;

        SceneManager.LoadScene("MainMenu");
    }
}
