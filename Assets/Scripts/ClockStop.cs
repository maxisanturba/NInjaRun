using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockStop : EnemiesAndPowerups
{
    private void FixedUpdate()
    {
        MoveToLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("powerup");
            GameObject.Find("GameControl").GetComponent<GameControl>().isClockPaused = true;
            Destroy(gameObject);
        }
    }
}
