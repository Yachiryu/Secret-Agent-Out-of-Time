using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDialogos : MonoBehaviour
{
    PlayerMovement playerMove;
    public Animator animator;
    GameObject cinePrincipio;

    private void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaDialogo"))
        {
            animator.SetFloat("isRuning",0);
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);


            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
            
            playerMove.rb.velocity = new Vector2(0,0);
        }
        else
        {
            GetComponent<PlayerShoot>().enabled = true;
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
}
