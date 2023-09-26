using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimerUI : MonoBehaviour
{
    private float timeLeft = 60f;
    private bool isPaused = false;
    public bool isGameOver = false; // Add this variable to track if the game is over

    public GameObject gameOverOverlay; // Reference to your game over overlay GameObject

    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!isPaused && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (!isGameOver) // Check if the game is not already over
        {
            // Timer has ended, call the game over function
            Debug.Log("timer ui else if gameover");
            GameOver();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if (timeLeft <= 10)
        {
            timerText.color = Color.red;
            timerText.fontSize = 25f;
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void AddTime(float secondsToAdd)
    {
        timeLeft += secondsToAdd;
    }

    private void GameOver()
    {
        // Set the game over state
        isGameOver = true;
        Debug.Log("gameoveroverlay caleed from timer ui");
        // Activate the game over overlay
        gameOverOverlay.SetActive(true);
        Invoke("LoadMainScene", 5f);
    }
    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");  
    }
}
