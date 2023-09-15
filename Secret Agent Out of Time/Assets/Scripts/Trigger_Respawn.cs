using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private void Start()
    {
        respawnPoint= transform.position;
    }

    private void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint= transform.position;
        }
    }
}
