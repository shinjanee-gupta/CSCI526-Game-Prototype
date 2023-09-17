using System.Collections;
using UnityEngine;

public class GroundCrumble : MonoBehaviour
{
    private bool playerHasStarted = false;
    private const float totalTime = 40f;
    private float timePassedSinceStart = 0f;
    private float crumbleThreshold = 2f; // start crumbling every 2 seconds
    private bool isCrumblingPaused = false;

    void Update()
    {
        // Start the timer only if the player has started
        if (playerHasStarted)
        {
            timePassedSinceStart += Time.deltaTime;

            // Stop crumbling after 5 minutes
            if (timePassedSinceStart >= totalTime)
            {
                playerHasStarted = false; // Stop further crumbling
                return; // Exit out of Update
            }

            // Check if we reached the time to start crumbling
            if (timePassedSinceStart >= crumbleThreshold && !isCrumblingPaused)
            {
                CrumbleGroundSegment();
                timePassedSinceStart = 0f; // Reset the timer for the next crumble
            }
        }
    }

    private void CrumbleGroundSegment()
    {
        Debug.Log("Attempting to crumble ground segment");
        // Logic to identify and crumble the next ground segment
        GameObject nextSegment = GetNextGroundSegment();
        if (nextSegment != null)
        {
            Debug.Log("Destroying: " + nextSegment.name);
            Destroy(nextSegment);
        }
    }

    private GameObject GetNextGroundSegment()
    {
        // Return the first segment of the ground to be crumbled (the one at the beginning of the track)
        Transform parent = this.transform;
        if (parent.childCount > 0)
        {
            return parent.GetChild(0).gameObject; 
        }
        return null;
    }

    public void StartPlayerMovement()
    {
        Debug.Log("Ground crumbling has started!");
        playerHasStarted = true;
    }

    public void PauseCrumblingForSeconds(float seconds)
    {
        StartCoroutine(PauseCrumblingCoroutine(seconds));
    }

    private IEnumerator PauseCrumblingCoroutine(float seconds)
    {
        isCrumblingPaused = true;
        yield return new WaitForSeconds(seconds);
        isCrumblingPaused = false;
    }
}