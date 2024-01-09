using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parámetros movimiento")]
    public Rigidbody2D rb;
    public float move;
    public float velocidad;
    public float salto;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;
    [SerializeField] float numSalto;

    private bool isFacingRight, enSuelo;
    //bool jump = false;
    public bool isCrouched = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        isFacingRight = true;
    }
    private void FixedUpdate()
    {
        // Condiciones y fisicas del salto personaje
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() || Input.GetAxis("Vertical") > 0.1 && IsGrounded())
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(new Vector2(rb.velocity.x, salto * 10));
        }

        // Fisicas movimiento del personaje
        rb.velocity = new Vector2(move * velocidad, rb.velocity.y);
    }

    private void Update()
    {
        //Debug.Log(Input.GetAxis("Vertical") + "Input vertical" );/////////////////

        move = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("isRuning", Mathf.Abs(move));

        if(IsGrounded()) 
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (!IsGrounded())
        {
            anim.SetBool("isFalling", true);
            //anim.SetBool("isJumping", true);
        } 

        IsCrouching();

        /*if (move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }*/
        if (!IsGrounded())
        {
            rb.gravityScale = 2;
        }
        if (IsGrounded())
        {
            StartCoroutine(IsJumping());
        }

        //anim.SetBool("isJumping", !isGrounded());

        if (!isFacingRight && move > 0)
        {
            Flip();
        }
        else if (isFacingRight && move < 0)
        {
            Flip();
        }

    }

    public void IsCrouching() 
    {
        if (Input.GetAxis("Vertical") <= -0.1 && IsGrounded() 
            && move == Mathf.Clamp((Input.GetAxisRaw("Horizontal")),-0.1f,0.1f))
        {
            isCrouched = true;
            anim.SetBool("isCrouching", true);

        }
        else
        {
            isCrouched = false;
            anim.SetBool("isCrouching", false); 
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public bool IsGrounded()
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

    IEnumerator IsJumping()
    {
        yield return new WaitForSeconds(1);
        rb.gravityScale = 1;
        yield break;
    }
 
}
