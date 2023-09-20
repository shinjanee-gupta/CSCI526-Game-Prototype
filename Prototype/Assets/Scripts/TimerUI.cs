using UnityEngine;
using TMPro;
using System.Collections;

public class TimerUI : MonoBehaviour
{
    public float timeLeft = 40f;
    private bool isPaused = false;

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
    }

    private void UpdateTimerDisplay()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void PauseTimer5s()
    {
        if (!isPaused)
        {
            StartCoroutine(PauseTimerForSeconds(5f));
        }
    }

    private IEnumerator PauseTimerForSeconds(float seconds)
    {
        isPaused = true;
        yield return new WaitForSeconds(seconds);
        isPaused = false;
    }
}
