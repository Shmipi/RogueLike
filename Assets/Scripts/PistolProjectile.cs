using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolProjectile : ProjectileScript
{
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 20f;
        damage = 4f;

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
