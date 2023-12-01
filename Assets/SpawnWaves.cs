using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    [SerializeField] GameObject[] spawnLocations;
    [SerializeField] GameObject[] enemies;
    

    private bool hasSpawned = false;
    private bool bossSpawn = false;
   
  
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        // Add spawn counter before boss fight?
        if (!hasSpawned && !bossSpawn)
        {
            hasSpawned = true;
            GameObject enemy = ChooseRandomEnemy();
            Transform enemyLocation = ChooseRandomSpawnLocation();
            GameObject spawnedEnemy = Instantiate(enemy, enemyLocation);
        }
    }

    private Transform ChooseRandomSpawnLocation() // Method for choosing a random spawn location and returning it.
    {
        int randNumber = Random.Range(0, 3);
        return spawnLocations[randNumber].transform;
    }

    private GameObject ChooseRandomEnemy() // Method for returning a random enemy from the enemies array.
    {
        int randNumber = Random.Range(0, 4);
        return enemies[randNumber];
    }
    public void SetHasSpawned(bool value)
    {
        hasSpawned = value;
    }

    
}
