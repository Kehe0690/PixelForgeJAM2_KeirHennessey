using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;

    public Rigidbody2D rb;

    [SerializeField] List<GameObject> gunList;
    public GameObject gun;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject machinegun;
    private bool pistolEquiped;
    private bool shotgunEquiped;
    private bool machinegunEquiped;
    private Vector2 mousePostion;
    private Vector2 gunDirection;
    public UnityEvent signalGunType;
    public float gunRadius;
    private Transform gunPivot;
    public Transform muzzle;

    public int maxHealth = 10;
    public int currentHealth;

    public HUDController healthBar;


    private void Start()
    {
        signalGunType.AddListener(GameObject.FindGameObjectWithTag("Muzzle").GetComponent<bulletController>().SwapGun);

        pistolEquiped = true;
        shotgunEquiped = false;
        machinegunEquiped = false;

        gunPivot = rb.transform;
        transform.parent = gunPivot;
        transform.position += Vector3.up * gunRadius;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        GunRotation();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(horizontal, vertical)*speed);
    }

    private void GunRotation()
    {
        Vector3 moustPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gunDirection = moustPosition - (Vector3)rb.position;
        float gunAngle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        if(gun != null)
        {
            gun.transform.position = (Vector3)rb.position + (Vector3)(gunDirection.normalized * gunRadius);
            gun.transform.rotation = Quaternion.AngleAxis(gunAngle, Vector3.forward);
        }
        

        if(gunAngle > -90 && gunAngle < 90)
        {
            if(gun != null)
            {
                gun.GetComponent<SpriteRenderer>().flipY = false;
            }
            
            
        }
        else
        {
            if (gun != null)
            {
                gun.GetComponent<SpriteRenderer>().flipY = true;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Shotgun"))
        {
            gun = gunList[1];
            pistol.SetActive(false);
            pistolEquiped = false;
            machinegun.SetActive(false);
            machinegunEquiped = false;
            shotgun.SetActive(true);
            shotgunEquiped = true;
            signalGunType.Invoke();
            healthBar.SetShotgunHUD();
            Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Machinegun"))
        {
            gun = gunList[2];
            pistol.SetActive(false);
            pistolEquiped = false;
            shotgun.SetActive(false);
            shotgunEquiped = false;
            machinegun.SetActive(true);
            machinegunEquiped = true;
            signalGunType.Invoke();
            healthBar.SetMachinegunHUD();
            Destroy(collision.gameObject);
        }
    }

    public string GetEquipedGun()
    {
        if (shotgunEquiped)
        {
            return "Shotgun";
        }
        else if (machinegunEquiped)
        {
            return "MachineGun";
        }
        else
        {
            return "Pistol";
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if(currentHealth<= 0)
        {
            healthBar.ToggleGameOver();
        }
    }

    public void NoAmmo()
    {
        gun = gunList[0];
        pistol.SetActive(true);
        pistolEquiped = true;
        shotgun.SetActive(false);
        shotgunEquiped = false;
        machinegun.SetActive(false);
        machinegunEquiped = false;
        healthBar.SetPistolHUD();
        signalGunType.Invoke();
    }
}
