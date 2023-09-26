using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    private TimerUI timerUI; // Reference to the TimerUI script
    private GroundCrumble groundCrumble; // Reference to the GroundCrumble script

    private void Start()
    {
        // Find and store references to the TimerUI and GroundCrumble scripts
        timerUI = FindObjectOfType<TimerUI>();
        groundCrumble = FindObjectOfType<GroundCrumble>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weak Point"))
        {
            Destroy(collision.gameObject);

            // Add 10 seconds to the timer
            timerUI.AddTime(5f);

            // Pause ground crumbling for 10 seconds
            groundCrumble.PauseCrumblingForSeconds(10f);
        }
    }
}
