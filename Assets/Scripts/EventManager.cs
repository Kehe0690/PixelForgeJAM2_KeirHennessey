using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private int waveNum;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float timeUntilSpawn;

    private bool currentlySpawning;

    


    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Start()
    {
        currentlySpawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0 && currentlySpawning)
        {
            SpawnEnemy();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void SpawnEnemy()
    {
        if(waveNum == 1 )
        {

            var randomSpawn = Random.Range(0, enemySpawnPoints.Count);
            Instantiate(enemyList[0],enemySpawnPoints[randomSpawn].position,Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }



    public void WaveFinished()
    {
        GameObject[] enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemiesOnScreen)
        {
            Destroy(enemy);
        }
        currentlySpawning = false;

    }
}
