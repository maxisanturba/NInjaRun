using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 0;
    [SerializeField] public float speed = 0;
    protected Collider2D collide2d;
    protected Rigidbody2D rb;
    protected Animator animator;
    [SerializeField] protected bool isGrounded;
    protected int stickDownLast;
    [SerializeField] protected int addScore = 0;

    protected float timer = 0;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        collide2d = GetComponent<Collider2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        VerticalMovement(jumpForce); //No funciona correctamente en el FixedUpdate
    }

    private void FixedUpdate()
    {
        HorizontalMovement(Input.GetAxisRaw("Horizontal"));
    }
    protected void HorizontalMovement(float direction)
    {
        if (stickDownLast == 1) 
        {
            timer += Time.deltaTime;
            if (timer >= .5f)
            {
                stickDownLast = 0;
                timer = 0;

                animator.SetBool("isDashing", false);
            }
        }
        if (stickDownLast == 0)
        {
            if (direction > 0)
            {
                rb.velocity = Vector2.right * speed;
                stickDownLast = 1;
                SoundManager.PlaySound("dash");
                animator.SetBool("isDashing", true);
            }
            else 

            if (direction < 0)
            {
                rb.velocity = Vector2.left * speed;
                stickDownLast = 1;
                SoundManager.PlaySound("dash");
                animator.SetBool("isDashing", true);
            }
        }
    }

    protected void VerticalMovement(float force)
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isJumping", true);

            if (isGrounded) 
            {
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                SoundManager.PlaySound("jump"); 
            }
        }
        else
            animator.SetBool("isJumping", false);

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isJumping", false);

            if (!isGrounded) 
            { 
                rb.AddForce(Vector2.down * (force * 2), ForceMode2D.Impulse); 
                SoundManager.PlaySound("dash"); 
            }
        }
    }

    protected bool EnemyDetection()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 5, 1 << 8)) return true;
        if (Physics2D.Raycast(transform.position, Vector2.up, 5, 1 << 8)) return true;
        else return false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jumped"))
        {
            GameObject.Find("GameControl").GetComponent<GameControl>().score += addScore;
        }
    }
}
