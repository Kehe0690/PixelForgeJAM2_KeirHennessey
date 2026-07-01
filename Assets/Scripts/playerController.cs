using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private Vector2 mousePostion;
    private Vector2 gunDirection;

    public float gunRadius;
    private Transform gunPivot;

    public Transform muzzle;


    private void Start()
    {
        gunPivot = rb.transform;
        transform.parent = gunPivot;
        transform.position += Vector3.up * gunRadius;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        GunRotation();
        print(gun);
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
            print("hit by enemy");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Shotgun"))
        {
            gun = gunList[1];
            pistol.SetActive(false);
            machinegun.SetActive(false);
            shotgun.SetActive(true);
            print("got shotgun");
        }
        else if (collision.gameObject.CompareTag("Machinegun"))
        {
            gun = gunList[2];
            pistol.SetActive(false);
            shotgun.SetActive(false);
            machinegun.SetActive(true);
            print("got machine gun");
        }
    }
}
