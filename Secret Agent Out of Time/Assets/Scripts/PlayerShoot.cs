using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparo();
        }
    }

    private void Disparo()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
