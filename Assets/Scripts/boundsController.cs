using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundsController : MonoBehaviour
{

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        
        if (collision.gameObject.CompareTag("Player"))
            {
                print("player is blocked");
                
            }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("in destroy");
            Destroy(collision.gameObject);
        }
    }
}
