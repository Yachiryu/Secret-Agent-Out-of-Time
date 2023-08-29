using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSett : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    [Range(-5,-15)] int asteroidSpeed;


    [SerializeField] GameObject explosionPref;
    [SerializeField]
    [Range(2, 8)] int multRotacion;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2D.angularVelocity = Random.Range(1,15) * multRotacion;
        //Debug.Log(rb2D.angularVelocity.ToString());
        rb2D.velocity = transform.up * asteroidSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZoneLimit")) return;

        Instantiate(explosionPref, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            Instantiate(explosionPref, collision.transform.position, Quaternion.identity);
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
