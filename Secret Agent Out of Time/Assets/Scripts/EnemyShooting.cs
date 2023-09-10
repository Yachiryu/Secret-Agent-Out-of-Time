using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float distanciaBala;

    private float tempo;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < distanciaBala)
        {
            tempo += Time.deltaTime;

            if (tempo > 1.5)
            {
                tempo = 0;
                Shoot();
            }
        }

        
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
