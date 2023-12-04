using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    [SerializeField] GameObject[] spawnLocations;
    [SerializeField] GameObject[] enemies;

    [SerializeField] GameObject boss_Lvl_1_Prefab;
    private GameObject boss;
    [SerializeField] Transform bossSpawnLocation;
    [SerializeField] Transform bossMoveTo;
    [SerializeField] Transform bossUpperBoundary;
    [SerializeField] Transform bossLowerBoundary;
    [SerializeField] Sprite[] bossShieldSprites;
    [SerializeField] ShieldFollowBoss shieldFollowBoss;
    private bool hasReachedUpper;
    private bool hasReachedLower;
    private bool atFirstBossPosition;
    private Transform bossLocation;

    [SerializeField] LevelManager levelManager;

    
    private bool hasSpawned = false;
    private bool bossSpawn = false;
    private bool timerFinished;
    private int bossHealth;

    [SerializeField] float bossSpeed = 3f;

    private void Start()
    {   
        atFirstBossPosition = false;
    }
    void Update()
    {
        SpawnEnemies();
        CheckTimerComplete();
        SpawnBossLevel1();
        MoveBoss();
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
    public void SetHasSpawned(bool value) // Metgod to allow the ability to set the enemy spawn value in other scripts.
    {
        hasSpawned = value;
    }

    private void CheckTimerComplete() // Assigns the timer complete method from the level manager script to a private bool.
    {
        timerFinished = levelManager.GetTimerFinished();
    }

    private void SpawnBossLevel1() // Spawns the boss
    {
        if (timerFinished && !bossSpawn)
        {
            bossSpawn = true;
            bossHealth = 4;
            boss = Instantiate(boss_Lvl_1_Prefab, bossSpawnLocation);
            shieldFollowBoss.SetShieldSprite(bossShieldSprites[0]);
        }   

        if (bossHealth == 3)
        {
            shieldFollowBoss.SetShieldSprite(bossShieldSprites[1]);
        }

        if (bossHealth == 2)
        {
            shieldFollowBoss.SetShieldSprite(bossShieldSprites[2]);
        }

        if (bossHealth == 1)
        {
            shieldFollowBoss.SetShieldSprite(bossShieldSprites[3]);
        }

        if (bossHealth == 0)
        {
            Destroy(boss);
        }

    }

    private void MoveBoss() // First, moves the boss into position, then creates a repeating upwards and downwards movement pattern.
    {
        if (bossSpawn && !atFirstBossPosition)
        {
            bossLocation = boss.transform;
            boss.transform.position = Vector2.MoveTowards(boss.transform.position, bossMoveTo.position, bossSpeed * Time.deltaTime);
            if (boss.transform.position == bossMoveTo.position)
            {
                atFirstBossPosition = true;
               
            }
        }
        else if (atFirstBossPosition)
        {
            bossLocation = boss.transform;
            if (!hasReachedUpper)
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, bossUpperBoundary.position, bossSpeed * Time.deltaTime);
                if (boss.transform.position == bossUpperBoundary.position)
                {
                    hasReachedUpper = true;
                    hasReachedLower = false;
                }
            }

            else if (!hasReachedLower && hasReachedUpper)
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, bossLowerBoundary.position, bossSpeed * Time.deltaTime);
                if (boss.transform.position == bossLowerBoundary.position)
                {
                    hasReachedUpper = false;
                    hasReachedLower = true;
                }
            }
        }
        
    }

    public void DamageBoss()
    {
        bossHealth--;
        Debug.Log(bossHealth);
    }

    public int GetBossHealth() 
    {
        return bossHealth;
    }
 
    public bool GetBossSpawn()
    {
        return bossSpawn;
    }

    public Transform GetBossPosition()
    {
        return bossLocation;
    }
}
