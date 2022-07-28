using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo: MonoBehaviour
{
    public float velocidad;
    public Transform detectorColi;
    public float distanciaCol;
    [SerializeField] private bool moviendoderecha;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(detectorColi.position, Vector2.down, distanciaCol);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (infoSuelo == false)
        {
            Girar();
        }
    }

    public void Girar()
    {
        moviendoderecha = !moviendoderecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(detectorColi.transform.position, detectorColi.transform.position + Vector3.down * distanciaCol);
    }
}
