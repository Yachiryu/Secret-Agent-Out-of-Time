using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }
}
