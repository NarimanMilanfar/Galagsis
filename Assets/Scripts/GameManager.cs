using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Image image4;    //Game Over Image
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;    //Game Win Image


    public GameObject player1;
    public GameObject player2;
    public Transform playerSpawn;
    private GameObject player;
    private WaitForSeconds wait;
    bool isPlayer1 = true;

    //below is for if/when I update the Game Over script
    private bool isGameOver = false;

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

        UpdateScoreUI();
        UpdateHealthUI();

        if (timerManager != null)
        {
            timerManager.InitializeTimer(this);
        }
    }
    private void Update()
    {
        //I will uncomment this code later if/when I implement fixed game over
         if(isGameOver)
         {
            return;
         }
         

        if (score > 33 && isPlayer1) {
            Destroy(player);
            player = Instantiate(player2, playerSpawn.position, playerSpawn.rotation);
            isPlayer1 = false;
        }

        player.transform.position = playerSpawn.position;

        if (score > 33 && score <= 66)
        {
            image6.gameObject.SetActive(true);

            image5.gameObject.SetActive(false);
        }

        if (score > 66)
        {
            levelup();
        }

        if (score >= 100)
        {
            //image8.gameObject.SetActive(true);
            //change this to a GameWon method
            GameWon();
        }



    }
    public void AddScore(int amount)
    {
        //Uncomment when implementing game over fix
        if(isGameOver) return;

        score += amount;
        UpdateScoreUI();
    }
    public void DecreaseHealth(int amount)
    {
        //Uncomment when implementing game over fix
        if(isGameOver) return;

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
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(true);

            //Uncomment when implementing game over fix
            GameOver();
        }

    }

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

    public void TimeUp()
    {
        //commented out for different implementation
        isGameOver = true;

        Debug.Log("Time is Up!!");
        timerManager.timerOn = false;
        image3.gameObject.SetActive(false);
        image4.gameObject.SetActive(true);
        timerText.text = "Time is Up!!";
    }

    public void GameOver()
    {
        //Uncomment when implementing game over fix
        isGameOver = true;
        Debug.Log("Game Over");
        timerManager.timerOn = false;
        timerText.text = "Game Over";
        timerManager.timeLeft = 0;
    }

    public void GameWon()
    {
        //Uncomment when implementing game over fix
        isGameOver = true;
        Debug.Log("Game Won");
        timerManager.timerOn = false;
        timerText.text = "Game Won";
        timerManager.timeLeft = 0;
        image8.gameObject.SetActive(true);
    }
}
