using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetBlock : MonoBehaviour
{
    private int flag_moved = 0; //1 for x ; 2 for letter
    private float initialPositionX;
    private float blockWidth;
    private bool isMovedRight = false;
    private bool isMovedLeft = false;
    private Rigidbody2D rb;

    public float moveSpeed = 1.0f;
    private Vector2 targetPosition;
    private bool isMoving = false;

    //public GameObject letterObject;
    public int correctOrder; // This will be set in the inspector for each block.
    public static int currentOrder = 0; // This will track the overall order.
    public WallManager wallManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPositionX = transform.position.x;
        blockWidth = GetComponent<Collider2D>().bounds.size.x;
        wallManager = FindObjectOfType<WallManager>();

    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if ((Vector2)transform.position == targetPosition)
                isMoving = false;
        }
        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
            if (isMovedRight)
            {
                //letterObject.SetActive(true);
                //wallManager.ShowAlpha(currentOrder);
                // After moving it to the right, check if this block is the next in the sequence
                if (correctOrder == currentOrder + 1)
                {
                    flag_moved = 2; //indicates correct letter was moved
                    currentOrder++;
                    Debug.Log("corrent order:" + currentOrder);
                    //letterObject.SetActive(true); // Show the correct letter.
                    wallManager.ShowAlpha(correctOrder);
                    wallManager.CheckCompletion();                            
                }
                else
                {
                    Debug.Log("corrent orderf rom else:" + currentOrder);
                    wallManager.ShowX(currentOrder);
                    flag_moved = 1; //indicates wrong block was moved 
                }
            }
            else if (isMovedLeft)
            {
                if (correctOrder == currentOrder)
                {
                    currentOrder--;
                    if (currentOrder < 0)
                    {
                        currentOrder = 0;
                    }
                }
                //letterObject.SetActive(false);  // Deactivate the letter when block returns to the original position.
                if(flag_moved == 1)
                {
                    wallManager.HideX(currentOrder);
                }
                else
                {
                    wallManager.HideAlpha(currentOrder);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check for side collision
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.Log("inside contacts");
                Debug.Log("Contact Normal: " + contact.normal);
                // if (contact.normal.y >= 0)
                {
                    Debug.Log("contact made on the sides");
                    // Determine the direction from which the player has collided
                    float direction = collision.transform.position.x - transform.position.x;

                    // Player comes from the left
                    if (direction < 0 && !isMovedRight)
                    {
                        Debug.Log("moving it to right");
                        // float newPositionX = initialPositionX + blockWidth;
                        targetPosition = new Vector2(initialPositionX + blockWidth, transform.position.y);

                        // transform.position = new Vector2(newPositionX, transform.position.y);
                        isMovedRight = true;
                        isMovedLeft = false;
                        isMoving = true;
                        rb.isKinematic = true;

                                
                    }
                    // Player comes from the right
                    else if (direction > 0 && !isMovedLeft)
                    {
                        Debug.Log("moving it to left");
                        // float newPositionX = initialPositionX - blockWidth;
                        targetPosition = new Vector2(initialPositionX, transform.position.y);

                        // transform.position = new Vector2(newPositionX, transform.position.y);
                        isMovedRight = false;
                        isMovedLeft = true;
                        isMoving = true;
                        rb.isKinematic = true;  
                    }
                    break;
                }
            }
        }
    }
}
