using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;


    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.drag = 1;
            rb.AddForce(Vector2.down * 100);
        }
    }

    private void Update()
    {
        if (rb.velocity.magnitude <= 0)
        {
            Debug.Log("stop bullet");
        }
    }
}
