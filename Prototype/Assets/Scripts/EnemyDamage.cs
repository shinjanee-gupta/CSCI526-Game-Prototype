using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public TimerUI timerUI;

    private void Start()
    {
        timerUI = FindObjectOfType<TimerUI>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            timerUI.PauseTimer5s();
        }
    }
}
