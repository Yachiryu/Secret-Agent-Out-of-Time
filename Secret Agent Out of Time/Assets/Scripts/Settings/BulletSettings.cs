using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    private Transform transformer;
    [SerializeField] int bulletSpeed;

    private void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        transformer = GetComponent<Transform>();
    }
    void Start()
    {
        rbBullet.velocity = transform.up * bulletSpeed;
        transform.rotation = Quaternion.Euler(0,0,90);
    }

}
