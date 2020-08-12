using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float bulletForce = 20f; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        void Shoot()
        {
            //create bullet at firepoint
            GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            //apply force to bullet
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
         
        }
    }
}