using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : EnemiesAndPowerups
{
    [SerializeField] protected BoxCollider2D bc2d;
    [SerializeField] protected Animator animator;
    protected float timeToJump = 0;
    protected float timer = 0;

    private void OnEnable()
    {
        bc2d = GetComponent<BoxCollider2D>();
        timeToJump = Random.Range(rangeMin, rangeMax);
    }

    private void FixedUpdate()
    {
        MoveToLeft();

        timer += Time.deltaTime;

        if (timer >= timeToJump)
        {
            animator.SetBool("isJumping", true);
            Jumping();
        }
        else animator.SetBool("isJumping", false);
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