using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;

    public Rigidbody2D rb;


    [SerializeField] private GameObject gun;
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
        gun.transform.position = (Vector3)rb.position + (Vector3)(gunDirection.normalized * gunRadius);
        gun.transform.rotation = Quaternion.AngleAxis(gunAngle, Vector3.forward);

        if(gunAngle > -90 && gunAngle < 90)
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
            
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //print("BANG");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("hit by enemy");
        }
    }
}
