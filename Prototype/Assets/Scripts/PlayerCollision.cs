using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    public float upwardForce = 500.0f;
    public float backwardForce = 200.0f;
    public GameObject gameOverOverlay;
    public GameObject HintText;
    public GameObject Hint2;
    public TimerUI timerUI;
    public GroundCrumble groundCrumble;

    // Store a reference to the currently running hint coroutine.
    private Coroutine hintCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerUI = FindObjectOfType<TimerUI>();
        groundCrumble = FindObjectOfType<GroundCrumble>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector2 force = new Vector2(-backwardForce, upwardForce);
            rb.AddForce(force);

            this.GetComponent<PlayerMovement>().enabled = false;

            gameOverOverlay.SetActive(true);

            timerUI.PauseTimer();
            groundCrumble.StopCrumbling();
        }

        if (collision.gameObject.CompareTag("HintText"))
        {
            // Enable the HintText
            HintText.SetActive(true);

            // If a hint coroutine is already running, stop it.
            if (hintCoroutine != null)
            {
                StopCoroutine(hintCoroutine);
            }

            // Start a new coroutine to disable HintText after 5 seconds.
            hintCoroutine = StartCoroutine(DisableHintAfterDelay(5f));
        }


        if (collision.gameObject.CompareTag("Hint2"))
        {
            // Enable the HintText
            Hint2.SetActive(true);

            // If a hint coroutine is already running, stop it.
            if (hintCoroutine != null)
            {
                StopCoroutine(hintCoroutine);
            }

            // Start a new coroutine to disable HintText after 5 seconds.
            hintCoroutine = StartCoroutine(DisableHintAfterDelay(5f));
        }
    }



    private IEnumerator DisableHintAfterDelay(float delay)
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Disable the HintText after the delay.
        HintText.SetActive(false);
    }
}
