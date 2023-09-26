using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f; // Jump force for player
    public static GroundCrumble groundCrumble;
    private bool hasMovedForward = false;
    private bool isGrounded = true;  // Mechanism to check if player is on ground
    private Rigidbody2D rb;
    public GameObject endGameOverlay;
    public TimerUI timerUI; 

    public GameObject gameOverOverlay;

    private float yValue;

    //public static parentGroundObject="GroundParent";

    public static bool scenechanged = false;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        groundCrumble = GameObject.Find("GroundParent").GetComponent<GroundCrumble>();
        yValue   = 1.4f;
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
        
        if(transform.position.y < yValue)
        {
            gameOverOverlay.SetActive(true);
            timerUI.PauseTimer();  
            this.enabled = false; //stop player movement
            groundCrumble.StopCrumbling();
            Invoke("LoadMainScene", 5f);
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
            Debug.Log("Last tag called");
            ShowEndGameOverlay();
        }
    }

    public void ShowEndGameOverlay()
    {
        endGameOverlay.SetActive(true);  // Show the overlay
        timerUI.PauseTimer();  
        this.enabled = false; //stop player movement
        groundCrumble.StopCrumbling();
        Invoke("LoadMainScene", 5f);  // Call LoadMainScene after 10 seconds
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");  // Replace "MainScene" with the actual name of your main scene
    }

}