using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private float maxDespawnTime;
    [SerializeField] private float minDespawnTime;
    [SerializeField] private float timeUntilDespawn;

    void Awake()
    {
        SetTimeUntilDespawn();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilDespawn -= Time.deltaTime;
        if (timeUntilDespawn <= 0)
        {
            DespawnWeapon();
        }
    }

    private void SetTimeUntilDespawn()
    {
        timeUntilDespawn = Random.Range(minDespawnTime, maxDespawnTime);
    }

    private void DespawnWeapon()
    {
        Destroy(gameObject);
    }
}
