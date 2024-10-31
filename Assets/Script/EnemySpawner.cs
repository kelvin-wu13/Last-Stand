using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnpoints;

    public GameObject enemy;
    
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 5 , 10);
    }

    void SpawnEnemy() {
        int r = Random.Range(0, spawnpoints.Length);
        GameObject myEnemy = Instantiate(enemy, spawnpoints[r].position, Quaternion.identity);
    }
}

