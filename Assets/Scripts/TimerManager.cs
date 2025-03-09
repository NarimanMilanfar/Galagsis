using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public GameManager gameManager;

    //Initialize the timer
    public void InitializeTimer(GameManager gameManager)
    {
        this.gameManager = gameManager;
        timerOn = true;
        timeLeft = 300f;
        gameManager.UpdateTimerUI(timeLeft);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = GameManager.Instance;
        }
        timerOn = true;
        if (gameManager != null)
        {
            gameManager.UpdateTimerUI(timeLeft);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if (gameManager != null)
                {
                    gameManager.UpdateTimerUI(timeLeft);
                }
            }
            else
            {
                timeLeft = 0;
                timerOn = false;

                if (gameManager != null)
                {
                    gameManager.TimeUp();
                }
            }
        }
    }
}
