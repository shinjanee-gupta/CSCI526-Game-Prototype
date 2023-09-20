using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public TimerUI timerUI;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
            timerUI.PauseTimer5s();
        }
    }


}
