using UnityEngine;

public class TriggerCameraMove : MonoBehaviour
{
    public Camera mainCamera; 
    private float moveDistance; 

    private void Start()
    {
        // Calculate camera's view width based on its size and screen's aspect ratio
        moveDistance = 2f * mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            Vector3 cameraNewPos = mainCamera.transform.position;
            cameraNewPos.x += moveDistance;
            mainCamera.transform.position = cameraNewPos;
        }
    }
}
