using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    public float upwardForce = 500.0f;  
    public float backwardForce = 200.0f; 
    public GameObject gameOverOverlay;
    public GameObject HintText;
    public TimerUI timerUI;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerUI = FindObjectOfType<TimerUI>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 force = new Vector2(-backwardForce, upwardForce);
            rb.AddForce(force);

            this.GetComponent<PlayerMovement>().enabled = false;
            gameOverOverlay.SetActive(true);
            timerUI.PauseTimer();  
            HintText.SetActive(false);
        }
    }
}