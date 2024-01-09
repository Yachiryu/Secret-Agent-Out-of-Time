using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] private Transform disparonormal;
    [SerializeField] private Transform disparoAgachado;
    [SerializeField] private GameObject bala;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparo();
        }
    }

    private void Disparo()
    {
        if (playerMovement.isCrouched == false)
        {
            Instantiate(bala, disparonormal.position, disparonormal.rotation);
            Debug.Log("DisparoParado");
        }
        else
        {
            Instantiate(bala, disparoAgachado.position, disparoAgachado.rotation);
            Debug.Log("DisparoAgacahdo");
        }
    }
}
