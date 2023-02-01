using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunProjectile : ProjectileScript
{
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 10f;
        damage = 2f;

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
