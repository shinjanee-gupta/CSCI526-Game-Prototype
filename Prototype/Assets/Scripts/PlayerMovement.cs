using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public GroundCrumble groundCrumble;
    private bool hasMovedForward = false;
    private Rigidbody2D rb;

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
    }
}
