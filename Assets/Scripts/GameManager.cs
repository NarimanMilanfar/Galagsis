using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TimerManager timerManager;
    public int score { get; private set; } = 0;
    private int health = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;
    public Image health1;
    public Image health2;
    public Image health3;
    public Image gameOverImage;    // Game Over Image
    public Image level1;
    public Image level2;
    public Image level3;
    public Image winImage;    //Game Won Image
    public GameObject player1;
    public GameObject player2;
    public Transform playerSpawn;
    private GameObject player;
    private WaitForSeconds wait;
    bool isPlayer1 = true;
    private int scoreUI;

    public Image healthBar;

    public TextMeshProUGUI highScoreText;
    private float finalTimeTaken;

    //public TextMeshProUGUI healthText;

    public bool isGameOver = false;
    public Button restartButton;
    public Button backToMainMenuButton;

    private AudioManager audioManager;

    public int rowCount;
    public Image multiplier2;
    public Image multiplier3;
    // For Level Up Screen

    public GameObject levelUpUI;
    private bool isLevelingUp = false;
    private int currentLevel = 1;


    void Awake()
    {
        // executing singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Instantiate(player1, playerSpawn.position, playerSpawn.rotation);


        if (SceneManager.GetActiveScene().name == "Level2")
        {
            scoreUI = 0;
            score = 34;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            scoreUI = 0;
            score = 67;
        }

        if (multiplier3 != null)
        {
            multiplier3.gameObject.SetActive(false);
        }

        if (multiplier2 != null)
        {
            multiplier2.gameObject.SetActive(false);
        }

        if (highScoreText != null)
        {
            highScoreText.gameObject.SetActive(false);
        }

        UpdateScoreUI();
        UpdateHealthUI();
        levelup();
        //initialize the timer
        if (timerManager != null)
        {
            timerManager.InitializeTimer(this);
        }
    }

    private void Update()
    {
        //This is how I stop the game from running once it ends
        //Just remove this line if you want to keep updating the game after it ends
        // if (isGameOver)
        // {
        //     return;
        // }

        if (score > 33 && isPlayer1)
        {
            Destroy(player);
            player = Instantiate(player2, playerSpawn.position, playerSpawn.rotation);
            isPlayer1 = false;
        }
        player.transform.position = playerSpawn.position;
        player.transform.rotation = playerSpawn.rotation;

        // Level 2
        if (score > 33 && score <= 66)
        {
            level2.gameObject.SetActive(true);
            level1.gameObject.SetActive(false);

            score = Mathf.Clamp(score, 33, 100);

            if (currentLevel < 2 && !isLevelingUp)
            {
                StartCoroutine(LevelUpSequence(2));
            }

        }
        // Level 3
        if (score > 66)
        {
            levelup();
            score = Mathf.Clamp(score, 66, 100);

            if (currentLevel < 3 && !isLevelingUp)
            {
                StartCoroutine(LevelUpSequence(3));
            }

        }

        if (scoreUI >= 100)
        {

            // Win Game
            //change this to a GameWon method
            GameWon();
        }
    }

    public void AddRowCount()
    {
        rowCount++;
    }

    public void ResetRowCount()
    {
        rowCount = 0;
    }

    public void ResetMultiplier()
    {
        ResetRowCount();
        SetX2Inactive();
        SetX3Inactive();
    }

    public void AddScore(int amount)
    {
        //This is how I stop the game from running once it ends
        //Just remove this line if you want to keep adding score after the game ends
        if (isGameOver) return;

        score += amount;
        scoreUI += amount;

        if (currentLevel == 1)
        {
            score = Mathf.Clamp(score, 0, 100);
            scoreUI = Mathf.Clamp(scoreUI, 0, 100);
        }
        else if (currentLevel == 2)
        {
            score = Mathf.Clamp(score, 33, 100);
            scoreUI = Mathf.Clamp(scoreUI, 0, 100);
        }
        else if (currentLevel == 3)
        {
            score = Mathf.Clamp(score, 67, 100);
            scoreUI = Mathf.Clamp(scoreUI, 0, 100);
        }

        UpdateScoreUI();

        // if (amount > 0)
        // {
        //     Debug.Log("Score increased by: " + amount);
        // }
        // else
        // {
        //     Debug.Log("Score decreased by: " + amount);
        // }
    }
    public void DecreaseHealth(int amount)
    {
        //This is how I stop the game from running once it ends
        //Just remove this line if you want to keep decreasing health after the game ends
        if (isGameOver) return;


        health -= amount;
        UpdateHealthUI();

        if (health >= 50 && health < 75)
        {
            health1.gameObject.SetActive(false);
        }
        else if (health >= 25 && health < 50)
        {
            health2.gameObject.SetActive(false);
        }
        else if (health <= 0)
        {

            // Game Over
            //Changed this to use the GameOver method
            GameOver();

        }
    }

    public void SetX2Active()
    {
        multiplier2.gameObject.SetActive(true);
        multiplier2.DOFade(1, 0.5f);
    }

    public void SetX3Active()
    {
        multiplier3.gameObject.SetActive(true);
        multiplier3.DOFade(1, 0.5f);
    }

    public void SetX2Inactive()
    {
        multiplier2.DOFade(0, 0.5f).OnComplete(() =>
        {
            multiplier2.gameObject.SetActive(false);
        });
    }

    public void SetX3Inactive()
    {
        multiplier3.DOFade(0, 0.5f).OnComplete(() =>
        {
            multiplier3.gameObject.SetActive(false);
        });
    }

    public void HealthBoost(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        UpdateHealthUI();
        Debug.Log("Health Boost! Current Health: " + health);
    }


    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.transform.DOScale(1.2f, 0.1f).OnComplete(() =>
           {
               scoreText.transform.DOScale(1f, 0.1f);
           });
            scoreText.text = "Score: " + scoreUI; // Method to constantly update UI text
        }
    }
    void UpdateHealthUI()
    {
        if (healthText != null && healthBar != null)
        {
            healthBar.fillAmount = health / 100f;
            healthText.text = "Health: " + health + "%"; // Method to constantly update UI text
        }
    }

    public void UpdateTimerUI(float timeLeft)
    {
        if (timerText != null)
        {
            //This is how I stop the game from running once it ends
            if (isGameOver)
            {
                return;
            }
            else
            {
                float minutes = Mathf.FloorToInt(timeLeft / 60);
                float seconds = Mathf.FloorToInt(timeLeft % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void levelup()
    {
        if (score > 66)
        {
            level3.gameObject.SetActive(true);
            level2.gameObject.SetActive(false);
            level1.gameObject.SetActive(false);
        }
        else if (score <= 33)
        {
            level1.gameObject.SetActive(true);
            level2.gameObject.SetActive(false);
            level3.gameObject.SetActive(false);
        }
        else if (score> 33 && score <= 66)
        {
            level2.gameObject.SetActive(true);
            level1.gameObject.SetActive(false);
            level3.gameObject.SetActive(false);
        }

    }

    // public void RestartGame()
    // {
    //     Cursor.visible = true;  // Show the cursor
    //     Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    public void GameOver()
    {
        //Moved Salma's code to this method 
        // Avoid overlap status or images
        if (winImage.gameObject.activeSelf)
        {
            // do nothing (skip game over cause already win)
            return;
        }

        health3.gameObject.SetActive(false);

        // Game Over Image
        gameOverImage.gameObject.SetActive(true);

        // Restart Button
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);

        // Back To Main Menu Button
        backToMainMenuButton.gameObject.SetActive(true);

        isGameOver = true;
        Debug.Log("Game Over");
        SetFinalTime(300 - timerManager.timeLeft);
        timerManager.timerOn = false;
        timerText.text = "Game Over";
        timerManager.timeLeft = 0;

        //Added Game Over audio here
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic(AudioManager.instance.gameOverClip);
        }

        CheckHighScore();
    }

    public void GameWon()
    {
        // Avoid overlap status or images
        if (gameOverImage.gameObject.activeSelf || isGameOver == true)
        {
            // do nothing (skip win cause already game over)
            return;
        }

        // Win Image
        winImage.gameObject.SetActive(true);

        // Restart Button
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);

        // Back To Main Menu Button
        backToMainMenuButton.gameObject.SetActive(true);

        isGameOver = true;
        Debug.Log("Game Won");
        SetFinalTime(300 - timerManager.timeLeft);
        timerManager.timerOn = false;
        timerText.text = "Game Won";
        timerManager.timeLeft = 0;
        winImage.gameObject.SetActive(true);

        //Added victory audio here
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic(AudioManager.instance.victoryClip);
        }

        CheckHighScore();
    }

    public float GetFinalTime()
    {
        return finalTimeTaken;
    }

    public void SetFinalTime(float time)
    {
        finalTimeTaken = time;
    }


    public void CheckHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        float highScoreTime = PlayerPrefs.GetFloat("HighScoreTime", 300);
        float currentTimeTaken = GetFinalTime();
        if (score >= highScore || (score >= 100 && currentTimeTaken < highScoreTime))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetFloat("HighScoreTime", currentTimeTaken);
        }

        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        // highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        float highScoreTime = PlayerPrefs.GetFloat("HighScoreTime", 300);

        int minutes = Mathf.FloorToInt(highScoreTime / 60);
        int seconds = Mathf.FloorToInt(highScoreTime % 60);

        highScoreText.text = $"High Score: {highScore} Time: {minutes}:{seconds:D2}";
        highScoreText.gameObject.SetActive(true);
    }

    public IEnumerator LevelUpSequence(int nextLevel)
    {
        isLevelingUp = true;

        // Shake the camera
        CameraShake.Shake(0.5f, 1f); // duration, strength

        // Play level up sound
        AudioManager.instance.PlaySound(AudioManager.instance.levelUpClip);

        // Show level-up UI
        levelUpUI.SetActive(true);

        yield return new WaitForSeconds(1f);

        levelUpUI.SetActive(false);

        currentLevel = nextLevel;
        isLevelingUp = false;

        if (nextLevel == 2 && isPlayer1)
        {
            Destroy(player);
            player = Instantiate(player2, playerSpawn.position, playerSpawn.rotation);
            isPlayer1 = false;

            level2.gameObject.SetActive(true);
            level1.gameObject.SetActive(false);
        }
        else if (nextLevel == 3)
        {
            levelup(); // Call your original level 3 method
        }
    }

    public void TriggerLevelUp()
    {
        if (isLevelingUp) return;

        StartCoroutine(LevelUpSequence(score == 33 ? 2 : 3));
    }
}

