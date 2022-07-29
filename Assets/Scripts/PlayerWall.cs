using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(GameObject.FindWithTag("Player").GetComponent<Transform>().transform.position.x, transform.position.y);
            //GameObject.FindWithTag("Player").GetComponent<Player>().speed = 0;
        }
    }
}
