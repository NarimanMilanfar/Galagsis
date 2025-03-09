using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //public TextMeshProUGUI healthText;

    public bool isGameOver = false;
    public Button restartButton;
    public Button backToMainMenuButton;

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
        levelup();

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            score = 34;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            score = 67;
        }

        UpdateScoreUI();
        UpdateHealthUI();

 MainMenu

        //initialize the timer
        if(timerManager != null)
        {
            timerManager.InitializeTimer(this);
        }

    private void Update()
    {
        //This is how I stop the game from running once it ends
        //Just remove this line if you want to keep updating the game after it ends
        if (isGameOver)
         {
            return;
         }
         

        if (score > 33 && isPlayer1) {
            Destroy(player);
            player = Instantiate(player2, playerSpawn.position, playerSpawn.rotation);
            isPlayer1 = false;
        }
        player.transform.position = playerSpawn.position;

        // Level 2
        if (score > 33 && score <= 66)
        {
            image6.gameObject.SetActive(true);

            image5.gameObject.SetActive(false);
        }
        // Level 3
        if (score > 66)
        {
            levelup();
        }
        if (score >= 100)
        {
 MainMenu
            // Avoid overlap status or images
            if (image4.gameObject.activeSelf)
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

            // Win Game
            //change this to a GameWon method
            GameWon();

    public void AddScore(int amount)
    {
        //This is how I stop the game from running once it ends
        //Just remove this line if you want to keep adding score after the game ends
        if (isGameOver) return;

        score += amount;
        UpdateScoreUI();
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
            // Avoid overlap status or images
            if (image8.gameObject.activeSelf)
            {
                // do nothing (skip game over cause already win)
                return;
            }

            image3.gameObject.SetActive(false);
 MainMenu

            // Game Over Image
            image4.gameObject.SetActive(true);

            // Restart Button
            Cursor.visible = true;  // Show the cursor
            Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
            restartButton.gameObject.SetActive(true);

            // Back To Main Menu Button
            backToMainMenuButton.gameObject.SetActive(true);

            // Game Over
            //Changed this to use the GameOver method
            GameOver();


    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Method to constantly update UI text
        }
    }
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
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

    public void RestartGame()
    {
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        //Moved Salma's code to this method 
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);   // restart button

        isGameOver = true;
        Debug.Log("Game Over");
        timerManager.timerOn = false;
        timerText.text = "Game Over";
        timerManager.timeLeft = 0;
        image4.gameObject.SetActive(true);
    }

    public void GameWon()
    {
        Cursor.visible = true;  // Show the cursor
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        restartButton.gameObject.SetActive(true);   // restart button

        isGameOver = true;
        Debug.Log("Game Won");
        timerManager.timerOn = false;
        timerText.text = "Game Won";
        timerManager.timeLeft = 0;
        image8.gameObject.SetActive(true);
    }


}
