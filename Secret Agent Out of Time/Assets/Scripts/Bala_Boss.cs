using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Boss : MonoBehaviour
{
    [SerializeField] GameObject explosionPref;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZoneLimit")) return;

        Instantiate(explosionPref, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            Instantiate(explosionPref, collision.transform.position, Quaternion.identity);
        }
        Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
