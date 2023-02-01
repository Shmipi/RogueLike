using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKProjectile : ProjectileScript
{
    void Start()
    {
        bulletSpeed = 25f;
        damage = 1f;

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
