using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class LimitesPantalla 
{
   public float xMinL, xMaxL, yMinL, yMaxL;
}

public class MovimientoNave : MonoBehaviour
{
    public LimitesPantalla limitMov;

    private Rigidbody2D rigidB2d;
    [SerializeField]
    [Range(3,10)] int multVelocidad;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float fireRate, nextFire;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet,bulletSpawn.position, Quaternion.identity);
        }

        /*Debug.Log("tiempo" + Time.time);
        Debug.Log("proximo disparo" + nextFire);*/
        
    }

    private void Awake()
    {
        rigidB2d = GetComponent<Rigidbody2D>();
    }
   
    private void FixedUpdate()
    {
        LimiteMov();

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalMove, verticalMove).normalized;
        rigidB2d.velocity = movement * multVelocidad;
    }

    public void LimiteMov()
    {
        rigidB2d.position = new Vector2(Mathf.Clamp(rigidB2d.position.x, limitMov.xMinL, limitMov.xMaxL),
        Mathf.Clamp(rigidB2d.position.y, limitMov.yMinL, limitMov.yMaxL));
    }

   
}

