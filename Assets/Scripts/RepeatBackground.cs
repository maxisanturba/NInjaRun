using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Bounds backgroundBounds;

    private void OnEnable()
    {
        backgroundBounds = GetComponent<SpriteRenderer>().bounds;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -backgroundBounds.extents.x * 2)
        {
            transform.Translate(new Vector3(backgroundBounds.extents.x * 4, 0, 0));
        }
    }
}
