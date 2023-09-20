using System.Collections;
using TMPro;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public TextMeshPro hintText;
    public float hintDisplayTime = 1f; // Change this to 5 seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayHint());
        }
    }

    private IEnumerator DisplayHint()
    {
        hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(hintDisplayTime);
        hintText.gameObject.SetActive(false);
    }
}
