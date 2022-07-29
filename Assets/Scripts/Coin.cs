using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : EnemiesAndPowerups
{
    [SerializeField] protected int addScore = 0;
    private void FixedUpdate()
    {
        MoveToLeft();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("coin");
            GameObject.Find("GameControl").GetComponent<GameControl>().score += addScore;
            Destroy(gameObject);
        }
    }

}
