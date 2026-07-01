using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bulletController : MonoBehaviour
{

    public Transform pistol;
    public Rigidbody2D bullet;
    public float bulletSpeed = 500f;

    private float fireRate = 0.5f;

    private float nextShot = 0f;

    [SerializeField] private playerController playerControllerScript;

    public string equipedGun;

    private void Start()
    {
        equipedGun = playerControllerScript.GetEquipedGun();
    }

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
        print("in shoot");
        if (equipedGun == "Pistol")
        {
            print(equipedGun);
            if (Input.GetMouseButtonDown(0))
            {
                nextShot = Time.time + fireRate;
                var firedBullet = Instantiate(bullet, pistol.position, pistol.rotation);
                firedBullet.AddForce(pistol.right * bulletSpeed);
            }
        }
        else if (equipedGun == "Shotgun")
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextShot = Time.time + fireRate;
                var firedBullet1 = Instantiate(bullet, pistol.position, pistol.rotation);
                var firedBullet2 = Instantiate(bullet, pistol.position, pistol.rotation);
                var firedBullet3 = Instantiate(bullet, pistol.position, pistol.rotation);
                firedBullet1.AddForce(pistol.right * bulletSpeed + new Vector3(0f,90f,0f));
                firedBullet2.AddForce(pistol.right * bulletSpeed);
                firedBullet3.AddForce(pistol.right * bulletSpeed + new Vector3(0f, -90f, 0f));
            }

        }
        else if (equipedGun == "MachineGun")
        {
            if (Input.GetMouseButton(0))
            {
                nextShot = Time.time + (fireRate-(float)0.25);
                var firedBullet = Instantiate(bullet, pistol.position, pistol.rotation);
                firedBullet.AddForce(pistol.right * bulletSpeed);
            }
            
        }
    }

    public void SwapGun()
    {
        print("gun swap");
        print(playerControllerScript.GetEquipedGun());
        equipedGun = playerControllerScript.GetEquipedGun();

    }
}
