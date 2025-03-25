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
    private int score = 0;
    private int health = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;    // Game Over Image
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;    //Game Won Image
    public GameObject player1;
    public GameObject player2;
    public Transform playerSpawn;
    private GameObject player;
    private WaitForSeconds wait;
    bool isPlayer1 = true;
    private int scoreUI;

    public Image healthBar;

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
            image6.gameObject.SetActive(true);
            image5.gameObject.SetActive(false);

            if (currentLevel < 2 && !isLevelingUp)
            {
                StartCoroutine(LevelUpSequence(2));
            }

        }
        // Level 3
        if (score > 66)
        {
            levelup();

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
        UpdateScoreUI();

        if (amount > 0)
        {
            Debug.Log("Score increased by: " + amount);
        } else {
            Debug.Log("Score decreased by: " + amount);
        }
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
            image1.gameObject.SetActive(false);
        }
        else if (health >= 25 && health < 50)
        {
            image2.gameObject.SetActive(false);
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

    public void EnemyHitObstacle()
    {
        Debug.Log("Enemy hit obstacle. Resetting multipliers.");
        ResetRowCount();
        SetX2Inactive();
        SetX3Inactive();
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
            image7.gameObject.SetActive(true);

            image6.gameObject.SetActive(false);
        }
        else
        {
            image5.gameObject.SetActive(true);

            image6.gameObject.SetActive(false);
            image7.gameObject.SetActive(false);
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
        if (image8.gameObject.activeSelf)
        {
            // do nothing (skip game over cause already win)
            return;
        }

        image3.gameObject.SetActive(false);

        // Game Over Image
        image4.gameObject.SetActive(true);

        // Restart Button
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);

        // Back To Main Menu Button
        backToMainMenuButton.gameObject.SetActive(true);

        isGameOver = true;
        Debug.Log("Game Over");
        timerManager.timerOn = false;
        timerText.text = "Game Over";
        timerManager.timeLeft = 0;

        //Added Game Over audio here
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic(AudioManager.instance.gameOverClip);
        }
    }

    public void GameWon()
    {
        // Avoid overlap status or images
        if (image4.gameObject.activeSelf || isGameOver == true)
        {
            // do nothing (skip win cause already game over)
            return;
        }

        // Win Image
        image8.gameObject.SetActive(true);

        // Restart Button
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);

        // Back To Main Menu Button
        backToMainMenuButton.gameObject.SetActive(true);

        isGameOver = true;
        Debug.Log("Game Won");
        timerManager.timerOn = false;
        timerText.text = "Game Won";
        timerManager.timeLeft = 0;
        image8.gameObject.SetActive(true);

        //Added victory audio here
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic(AudioManager.instance.victoryClip);
        }
    }

    public IEnumerator LevelUpSequence(int nextLevel)
    {
        isLevelingUp = true;
        currentLevel = nextLevel;

        // Play level-up sound
        if (AudioManager.instance != null && AudioManager.instance.levelUpClip != null)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.levelUpClip);
        }

        // Shake the camera
        CameraShake.Shake(0.5f, 1f);

        // Show level-up UI
        levelUpUI.SetActive(true);
        // levelUpUI.GetComponent<UnityEngine.UI.Text>().text = $"Level {nextLevel}!";

        yield return new WaitForSeconds(2f);

        levelUpUI.SetActive(false);

        // Apply changes per level
        if (nextLevel == 2 && isPlayer1)
        {
            Destroy(player);
            player = Instantiate(player2, playerSpawn.position, playerSpawn.rotation);
            isPlayer1 = false;
        }
        else if (nextLevel == 3)
        {
            levelup();
        }

        isLevelingUp = false;
    }



}

