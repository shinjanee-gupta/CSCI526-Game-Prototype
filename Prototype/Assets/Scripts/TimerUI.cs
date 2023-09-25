using UnityEngine;
using TMPro;
using System.Collections;

public class TimerUI : MonoBehaviour
{
    public float timeLeft = 40f;
    private bool isPaused = false;
    private bool isTimeFrozen = false;
    private float originalTimeScale;

    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        originalTimeScale = Time.timeScale;
    }

    private void Update()
    {
        if (!isTimeFrozen && !isPaused && timeLeft > 0)
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

    public void AddTime(float secondsToAdd)
    {
        timeLeft += secondsToAdd;
    }

    public void FreezeTime(float freezeDuration)
    {
        if (!isTimeFrozen)
        {
            isTimeFrozen = true;
            Time.timeScale = 0f; // Freeze time
            StartCoroutine(UnfreezeTimeAfterDelay(freezeDuration));
        }
    }

    private IEnumerator UnfreezeTimeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        isTimeFrozen = false;
        Time.timeScale = originalTimeScale; // Unfreeze time and restore the original time scale
    }
}
