using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Boss : MonoBehaviour
{
    public Transform firePoint_1;
    public Transform firePoint_2;

    public GameObject bulletPrefab; // Prefab de la bala
    public float bulletSpeed = 5.0f; // Velocidad de la bala
    public float fireRate = 2.0f; // Tasa de disparo (balas por segundo)
    public float bulletLifetime = 2.0f; // Tiempo de vida de la bala en segundos
    private float timeSinceLastShot = 0.0f;

    void Update()
    {
        // Actualiza el temporizador
        timeSinceLastShot += Time.deltaTime;

        // Dispara si ha pasado suficiente tiempo desde el último disparo
        if (timeSinceLastShot >= 1.0f / fireRate)
        {
            Shoot();
            timeSinceLastShot = 0.0f;
        }

    }

    void Shoot()
    {
        // Crea una instancia de la bala
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Ajusta la velocidad de la bala para que sea vertical
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed);

        // Destruye la bala después de un tiempo
        Destroy(bullet, bulletLifetime);
    }
}
