using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : EnemiesAndPowerups
{
    private void OnEnable()
    {
        speed = Random.Range(rangeMin, rangeMax); 
    }

    private void FixedUpdate()
    {
        MoveToLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObject.Find("GameControl").GetComponent<GameControl>().isClockPaused)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SoundManager.PlaySound("hit");
                GameObject.Find("GameControl").GetComponent<GameControl>().clock -= damageTime;
                GameObject.Find("GameControl").GetComponent<GameControl>().score -= damageScore;
                Destroy(gameObject);
            }
        }
    }
}
