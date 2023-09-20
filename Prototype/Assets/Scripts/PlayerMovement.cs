using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f; // Jump force for player
    public GroundCrumble groundCrumble;
    private bool hasMovedForward = false;
    private bool isGrounded = true;  // Mechanism to check if player is on ground
    private Rigidbody2D rb;
    public GameObject endGameOverlay;
    public TimerUI timerUI; 

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        groundCrumble = GameObject.Find("GroundParent").GetComponent<GroundCrumble>();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // If the player has moved forward and not yet triggered ground crumbling
        if (move > 0 && !hasMovedForward)
        {
            hasMovedForward = true;
            groundCrumble.StartPlayerMovement();
        }

        // Jump with space bar when the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Last"))
        {
            ShowEndGameOverlay();
        }
    }

    private void ShowEndGameOverlay()
    {
        endGameOverlay.SetActive(true);  // Show the overlay
        timerUI.PauseTimer();  
        this.enabled = false; //stop player movement
        groundCrumble.StopCrumbling();
        Invoke("LoadMainScene", 10f);  // Call LoadMainScene after 10 seconds
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");  // Replace "MainScene" with the actual name of your main scene
    }

}