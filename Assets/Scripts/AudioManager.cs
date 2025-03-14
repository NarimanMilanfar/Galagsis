using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool isGameOverMusicPlaying = false;

    [Header ("Audio Sources")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource rocketSource;

    [Header("Audio Clips")]

    public AudioClip backgroundClip;
    public AudioClip bulletClip;
    public AudioClip explosionClip;
    public AudioClip gameOverClip;
    public AudioClip victoryClip;
    public AudioClip rocketClip;
    public AudioClip buttonClip;

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
            if(musicSource.isPlaying)
            {
                musicSource.Stop();
            }
            musicSource.clip = backgroundClip;
            musicSource.loop = true;
            musicSource.Play();
            isGameOverMusicPlaying = false;
        }
    }

    public void PlayGameOverMusic(AudioClip clip)
    {
        if (musicSource != null && clip != null)
        {
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
            isGameOverMusicPlaying = true;
        }
    }

    public void PlaySound (AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayRocketSound()
    {
        if (rocketSource != null && !rocketSource.isPlaying)
        {
            rocketSource.clip = rocketClip;
            rocketSource.loop = true;
            rocketSource.Play();
        }
    }

    public void StopRocketSound()
    {
        if (rocketSource != null && rocketSource.isPlaying)
        {
            rocketSource.Stop();
        }
    }
}
