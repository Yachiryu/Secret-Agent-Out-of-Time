using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    private Rigidbody2D rigidB2d;
    private Vector3 velocidad = Vector3.zero;

    [SerializeField][Range(0.05f, 0.3f)] private float suavizadoDeMovimiento;
    [SerializeField] private float velocidadMovimiento;


    private void Start()
    {
        rigidB2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float movimientoVertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        Vector3 velocidadObjetivo = new Vector2(movimientoHorizontal, movimientoVertical);
        rigidB2d.velocity = Vector3.SmoothDamp(rigidB2d.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
    }
}

