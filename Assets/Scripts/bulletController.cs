using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    public Transform pistol;
    public Rigidbody2D bullet;
    public float bulletSpeed = 500f;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var firedBullet = Instantiate(bullet, pistol.position, pistol.rotation);
            firedBullet.AddForce(pistol.right * bulletSpeed);
        }
    }
}
