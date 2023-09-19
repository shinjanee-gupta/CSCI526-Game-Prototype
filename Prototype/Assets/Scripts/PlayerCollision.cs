using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject gameOverOverlay;  
    public TimerUI timerUI; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerUI = FindObjectOfType<TimerUI>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //after colliding, stop the timer and player movement
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.GetComponent<PlayerMovement>().enabled = false;

            gameOverOverlay.SetActive(true);
            
            timerUI.PauseTimer();  
        }
    }
}
