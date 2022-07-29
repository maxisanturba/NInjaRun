using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAndPowerups : MonoBehaviour
{
    [SerializeField] protected float speed = 0;
    [SerializeField] protected float rangeMin = 0;
    [SerializeField] protected float rangeMax = 0;
    [SerializeField] protected float damageTime = 0;
    [SerializeField] protected int damageScore = 0;
    [SerializeField] protected float distanceY;
    protected int direction = 0;
    protected Vector2 initPos;

    private void Awake()
    {
        initPos = transform.position;
    }

    protected virtual void MoveToLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Jumping()
    {
        float smoothSpeed = speed * Time.deltaTime;

        if (direction != 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (smoothSpeed * direction));
        }

        if (transform.position.y >= initPos.y + distanceY)
        {
            direction = -1;
        }
        if (transform.position.y <= initPos.y)
        {
            direction = 1;
        }
    }
}