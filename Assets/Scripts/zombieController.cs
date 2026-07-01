using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieController : MonoBehaviour
{

    public float moveSpeed;
    public int enemyHealth;
    [SerializeField] private List<GameObject> dropList;

    private Transform playerTarget;

    [SerializeField] private float dropRate;
    [SerializeField] private float dropNum;

    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, moveSpeed*Time.deltaTime);

        if (playerTarget.position.x - transform.position.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        enemyHealth -= 1;

        if(enemyHealth < 1)
        {
            SpawnDrop();
            Destroy(gameObject);
        }
    }

    private void SpawnDrop()
    {
        dropNum = Random.Range(0, dropRate);
        if(dropNum < 20)
        {
            Instantiate(dropList[Random.Range(0,dropList.Count)],transform.position, Quaternion.identity);
        }
    }
}
