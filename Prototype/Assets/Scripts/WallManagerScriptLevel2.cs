using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManagerScriptLevel2 : MonoBehaviour
{
    public GameObject[] wallObjects;
    public char crossValue = 'X';
    public GameObject riddleObject;
    private int i = -1;
    public static int[] filledPos = {0,0,0,0};
    public GameObject gameOverOverlay;
    public TimerUI timerUI;
    public GroundCrumble groundCrumble;
    public PlayerMovement playerMovementscript;
    int emptyIndex;

    int lastFilledIndex;

    public Dictionary<char, int> LetterCoding = new Dictionary<char, int>
    {
        {'H', 0},
        {'E', 1},
        {'L', 2},
        {'P', 3}    
    };
    // Start is called before the first frame update
    void Start()
    {
        playerMovementscript = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAlpha(char letter)
    {

        Debug.Log("Show alpha called :" + letter);
        Debug.Log("setting active alphaobject :" + letter);
        
        if (!LetterCoding.ContainsKey(letter))
        {
            emptyIndex = System.Array.IndexOf(filledPos,0);
            wallObjects[emptyIndex+4].SetActive(true);
            filledPos[emptyIndex] = 1;

        }else{
            Debug.Log("Show before i------------------->.>>> :" + i);
            i++;
            Debug.Log("Show i------------------->.>>> :" + i);
            wallObjects[LetterCoding[letter]].SetActive(true);
            filledPos[i] = 1;
            Debug.Log("filledPos in wallmgr xxxx"+string.Join(", ", filledPos));
        }
        
    }
    

    public void HideAlpha(char letter)
    {
        Debug.Log("Hide alpha called :" + letter);

        if (!LetterCoding.ContainsKey(letter))
        {
            lastFilledIndex = System.Array.LastIndexOf(filledPos,1);
            wallObjects[lastFilledIndex+4].SetActive(false);
            filledPos[lastFilledIndex] = 0;
        }
    }



    public void CheckCompletion()
    {
        if(AlphabetLevel2.fixCounter == 4)
        {  
            StartCoroutine(vanishWall());
            
        }
    }
    public IEnumerator vanishWall()
    {
        yield return new WaitForSeconds(3f);  // wait for 3 seconds
        riddleObject.SetActive(false);
        
        playerMovementscript.ShowEndGameOverlay();

    }

}