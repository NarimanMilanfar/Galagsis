using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header ("Audio Sources")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    //TODO: Add Rocket motion sound like in class demo??

    [Header("Audio Clips")]

    public AudioClip backgroundClip;
    public AudioClip bulletClip;
    public AudioClip explosionClip;
    public AudioClip gameOverClip;
    public AudioClip victoryClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Debug.Log("AudioManager Start");
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        Debug.Log("PlayBackgroundMusic");
        if (musicSource != null && backgroundClip != null)
        {
            musicSource.clip = backgroundClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySound (AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
