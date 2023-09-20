using System.Collections;
using TMPro;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public float hintDisplayTime = 10f;

    private void OnTriggerEnter2D(Collider2D other)
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
