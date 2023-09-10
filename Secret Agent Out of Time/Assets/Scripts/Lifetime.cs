using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float tiempoDeVida;

    private void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }
}
