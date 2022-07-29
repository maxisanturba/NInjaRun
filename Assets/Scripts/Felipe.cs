using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felipe : EnemiesAndPowerups
{
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
                //GameObject.Find("GameControl").GetComponent<GameControl>().gameIsOver = true;
                //GameObject.Find("GameControl").GetComponent<GameControl>().winPanel.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
