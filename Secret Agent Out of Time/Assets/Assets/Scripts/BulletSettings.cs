using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    [SerializeField] int bulletSpeed;

    private void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rbBullet.velocity = transform.up * bulletSpeed;
    }

}
