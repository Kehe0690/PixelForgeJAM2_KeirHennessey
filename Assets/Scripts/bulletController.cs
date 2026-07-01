using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    public Transform pistol;
    public Rigidbody2D bullet;
    public float bulletSpeed = 500f;

    private float fireRate = 0.5f;

    private float nextShot = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextShot)
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextShot = Time.time + fireRate;
            var firedBullet = Instantiate(bullet, pistol.position, pistol.rotation);
            firedBullet.AddForce(pistol.right * bulletSpeed);
        }
    }
}
