using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    private int health = 100;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    //public TextMeshProUGUI healthText;

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
        UpdateScoreUI();
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        UpdateHealthUI();
        if (health>=50 && health<75)
        {
            image1.gameObject.SetActive(false);
        }
        else if (health>=25&&health<50)
        {
            image2.gameObject.SetActive(false);
        }
        else if (health<=0)
        {
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(true);
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
            healthText.text = "Health: " + health+"%"; // Method to constantly update UI text
        }
    }
}
