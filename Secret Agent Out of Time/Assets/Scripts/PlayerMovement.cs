using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parámetros movimiento")]
    private Rigidbody2D rb;
    private float move;
    public float velocidad;
    public float salto;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;
    [SerializeField] float numSalto;

    private bool isFacingRight, enSuelo;
    bool jump = false;


    private void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * velocidad, rb.velocity.y);

        if (Input.GetButtonDown("Vertical") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, salto * 10));
        }

        if (move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (!isGrounded())
        {
            rb.gravityScale = 2;
        }
        if (isGrounded())
        {
            StartCoroutine(isJumping());
        }
      
        anim.SetBool("isJumping", !isGrounded());

        if (!isFacingRight && move > 0)
        {
            Flip();
        }
        else if (isFacingRight && move < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position -transform.up * castDistance, boxSize);
    }
    IEnumerator isJumping()
    {
        yield return new WaitForSeconds(1);
        rb.gravityScale = 1;
        yield break;
    }





}
