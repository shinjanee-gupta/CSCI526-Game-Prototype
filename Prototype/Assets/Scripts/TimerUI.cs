using UnityEngine;
using TMPro; // If using TextMeshPro

public class TimerUI : MonoBehaviour
{
    public float timeLeft = 40f;

    private TextMeshProUGUI timerText; 

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
