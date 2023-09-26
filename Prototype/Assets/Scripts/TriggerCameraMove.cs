using UnityEngine;
using System.Text.RegularExpressions; // Needed for Regex

public class TriggerCameraMove : MonoBehaviour
{
    public Camera mainCamera;
    private float moveDistance;
    private bool hasTriggeredCameraMove = false; // Flag to check if this box has already triggered a camera move

    public PlayerMovement playerMovementscript;

    private void Start()
    {
        // Calculate camera's view width based on its size and screen's aspect ratio
        moveDistance = 2f * mainCamera.orthographicSize * mainCamera.aspect;
        //playerMovementscript = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger");
        if (other.CompareTag("Player") && !hasTriggeredCameraMove) // If the player enters and the box hasn't triggered a move yet
        {
            Debug.Log("Player entered the trigger");
            Vector3 cameraNewPos = mainCamera.transform.position;
            cameraNewPos.x += moveDistance;
            mainCamera.transform.position = cameraNewPos;
            hasTriggeredCameraMove = true; // Set the flag to true so this box won't trigger a move again

            //PlayerMovement.scenechanged = true;
            PlayerMovement.groundCrumble = GameObject.Find("GroundParent_1").GetComponent<GroundCrumble>();
            Debug.Log("new parent for ground crumble "+ PlayerMovement.groundCrumble);

        }

        
    }
    
}
