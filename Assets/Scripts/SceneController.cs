using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        //Add audio for button click
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.buttonClip);
        }

        //Check if the audio needs to be reset
        bool isLoserMusicPlaying = AudioManager.instance.isLoserMusicPlaying;
        if (isLoserMusicPlaying==true)
        {
            AudioManager.instance.PlayBackgroundMusic();
        }

        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game...");

        //Add audio for button click
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.buttonClip);
        }

        // Quit the game when built
        Application.Quit();

        // Stop play mode in Unity Editor (only works inside Unity Editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
