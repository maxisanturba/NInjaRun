using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUp : EnemiesAndPowerups
{
    [SerializeField] protected float addTime = 0;
    private void FixedUpdate()
    {
        MoveToLeft();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("powerup");
            GameObject.Find("GameControl").GetComponent<GameControl>().clock += addTime;
            Destroy(gameObject);
        }
    }
}