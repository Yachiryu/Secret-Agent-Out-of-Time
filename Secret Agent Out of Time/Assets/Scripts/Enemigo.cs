using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vida;
    [SerializeField] private GameObject muerte;

    public void TakeDamage(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(muerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
