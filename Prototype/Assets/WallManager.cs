using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject[] XObjects;
    public GameObject[] AlphaObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAlpha(int index)
    {
        Debug.Log("Show alpha called :" + index);
        if (index >= 0 && index < AlphaObjects.Length)
            AlphaObjects[index].SetActive(true);
    }

    public void HideAlpha(int index)
    {
        Debug.Log("Hide alpha called :" + index);
        if (index >= 0 && index < AlphaObjects.Length)
            AlphaObjects[index].SetActive(false);
    }

    public void ShowX(int index)
    {
        Debug.Log("Show X called :" + index);
        if (index >= 0 && index < XObjects.Length)
            XObjects[index].SetActive(true);
    }

    public void HideX(int index)
    {
        Debug.Log("Hide alpha called :" + index);
        if (index >= 0 && index < XObjects.Length)
            XObjects[index].SetActive(false);
    }

    public void CheckCompletion()
    {
        if (AlphabetBlock.currentOrder == 4)  // Assuming there are 4 correct blocks.
        {
            // Code to remove or hide the wall.
        }
    }

}
