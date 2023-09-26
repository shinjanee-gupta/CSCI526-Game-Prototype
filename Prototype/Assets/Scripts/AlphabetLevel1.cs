using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetLevel1 : MonoBehaviour
{
    private float initialPositionX;
    private float blockWidth;
    private bool isMovedRight = false;
    private bool isMovedLeft = false;
    private Rigidbody2D rb;
    private char crossChar = 'X';
    public float moveSpeed = 1.0f;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private string targetWord = "HAIR";
    public static int fixCounter = 0;

    public WallManagerScriptLevel1 WallManagerScriptLevel1;
    
    public int CrossOrder = 0;
    public char letterValue = 'X';

    public static int curPos = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPositionX = transform.position.x;
        blockWidth = GetComponent<Collider2D>().bounds.size.x;
        WallManagerScriptLevel1 = FindObjectOfType<WallManagerScriptLevel1>();

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

                        Debug.Log("moving it to right xxxx"+letterValue);
                        targetPosition = new Vector2(initialPositionX + blockWidth, transform.position.y);

                        isMovedRight = true;
                        isMovedLeft = false;
                        isMoving = true;
                        rb.isKinematic = true;

                        if(letterValue == targetWord[curPos] && WallManagerScriptLevel1.filledPos[curPos]!=1)
                        { 
                            curPos = curPos + 1;
                            Debug.Log("curPos"+curPos);
                            WallManagerScriptLevel1.ShowAlpha(letterValue);
                            fixBlockPos();
                            WallManagerScriptLevel1.CheckCompletion(); 
                        }
                        else
                        {
                            WallManagerScriptLevel1.ShowAlpha(crossChar);
                        }
                                            
                    }
                    // Player comes from the right
                    else if (direction > 0 && !isMovedLeft)
                    {
                        Debug.Log("moving it to left");
                        targetPosition = new Vector2(initialPositionX, transform.position.y);

                        isMovedRight = false;
                        isMovedLeft = true;
                        isMoving = true;
                        rb.isKinematic = true;  
                        WallManagerScriptLevel1.HideAlpha(crossChar);
                    }
                    break;
                }
            }
        }
    }

    public void fixBlockPos()
    {
        fixCounter++;
        Debug.Log("block position fixed");
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }

}
