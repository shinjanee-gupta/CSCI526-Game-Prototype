using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f; // Jump force for player
    public GroundCrumble groundCrumble;
    private bool hasMovedForward = false;
    private bool isGrounded = true;  // Mechanism to check if player is on ground
    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        groundCrumble = GameObject.Find("GroundParent").GetComponent<GroundCrumble>();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Only allow movement if player is grounded
        if (isGrounded)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            // If the player has moved forward and not yet triggered ground crumbling
            if (move > 0 && !hasMovedForward)
            {
                hasMovedForward = true;
                groundCrumble.StartPlayerMovement();
            }
        }

        // Jump with space bar when the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    //only enable jump again when player landed on Ground
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y > 0.75f)  
                {
                    isGrounded = true;
                    return;  
                }
            }
        }
    }

}
