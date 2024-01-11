using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnWaves : MonoBehaviour
{
    [SerializeField] GameObject[] spawnLocations;
    [SerializeField] GameObject[] level_1_Enemies;
    [SerializeField] GameObject[] level_2_Enemies;
    [SerializeField] GameObject[] level_3_Enemies;

    private SpriteRenderer sr;
    [SerializeField] Sprite[] level_2_enemySprites;

    [SerializeField] GameObject boss_Lvl_1_Prefab;
    [SerializeField] GameObject boss_Lvl_2_Prefab;
    private GameObject boss;
    [SerializeField] Transform bossSpawnLocation;
    [SerializeField] Transform bossMoveTo;
    [SerializeField] Transform bossUpperBoundary;
    [SerializeField] Transform bossLowerBoundary;
    [SerializeField] Sprite[] bossShieldSprites;

    [SerializeField] Sprite[] bossSpellsBeingCast;
    [SerializeField] Sprite[] lv2_bossSpellsBeingCast;
    [SerializeField] SpriteRenderer bossSpellRenderer;
    private Sprite currentSpell;
    private bool isCastingSpell_1;
    private bool isCastingSpell_2;
    private bool isCastingSpell_3;
    private bool isCastingSpell_4;
    private bool isCastingSpell_5;
    private bool isCastingSpell_6;
    private bool isCastingSpell_7;
    private bool isCurrentlyCasting;

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

    private bool isLevelComplete;

    [SerializeField] float bossSpeed = 3f;

    private void Start()
    {   
        atFirstBossPosition = false;
    }
    void Update()
    {
        isLevelComplete = levelManager.GetLevelComplete();
        SpawnEnemies();
        CheckTimerComplete();
        SpawnBoss();
        MoveBoss();
    }

    private void SpawnEnemies()
    {
       
        if (!hasSpawned && !bossSpawn)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                hasSpawned = true;
                GameObject enemy = Level_1_ChooseRandomEnemy();
                Transform enemyLocation = ChooseRandomSpawnLocation();
                GameObject spawnedEnemy = Instantiate(enemy, enemyLocation);               
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                hasSpawned = true;
                GameObject enemy = Level_2_ChooseRandomEnemy();
                Transform enemyLocation = ChooseRandomSpawnLocation();
                GameObject spawnedEnemy = Instantiate(enemy, enemyLocation);            
            }
        }
    }

    private Transform ChooseRandomSpawnLocation() // Method for choosing a random spawn location and returning it.
    {
        int randNumber = Random.Range(0, 3);
        return spawnLocations[randNumber].transform;
    }

    private GameObject Level_1_ChooseRandomEnemy() // Method for returning a random enemy from the enemies array.
    {
        int randNumber = Random.Range(0, level_1_Enemies.Length);
        return level_1_Enemies[randNumber];
    }
    private GameObject Level_2_ChooseRandomEnemy() // Method for returning a random enemy from the enemies array.
    {
        int randNumber = Random.Range(0, level_2_Enemies.Length);
        GameObject enemy = level_2_Enemies[randNumber];
        sr = enemy.GetComponent<SpriteRenderer>();
        sr.sprite = level_2_enemySprites[randNumber];
        return enemy;
    }
    public void SetHasSpawned(bool value) // Metgod to allow the ability to set the enemy spawn value in other scripts.
    {
        hasSpawned = value;
    }

    private void CheckTimerComplete() // Assigns the timer complete method from the level manager script to a private bool.
    {
        timerFinished = levelManager.GetTimerFinished();
    }

    private void SpawnBoss() // Spawns the boss
    {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 1:

                    if (timerFinished && !bossSpawn && !isLevelComplete)
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

                    if (bossHealth == 0 && bossSpawn)
                    {
                        
                        levelManager.SetScore(50);
                        Destroy(boss);
                        StartCoroutine(EndLevel());
                    }
                    break;

                case 2:

                    if (timerFinished && !bossSpawn && !isLevelComplete)
                    {
                        bossSpawn = true;
                        bossHealth = 5;
                        boss = Instantiate(boss_Lvl_2_Prefab, bossSpawnLocation);
                        shieldFollowBoss.SetShieldSprite(bossShieldSprites[0]);
                    }

                    if (bossHealth == 4)
                    {
                        shieldFollowBoss.SetShieldSprite(bossShieldSprites[1]);
                    }

                    if (bossHealth == 3)
                    {
                        shieldFollowBoss.SetShieldSprite(bossShieldSprites[2]);
                    }

                    if (bossHealth == 2)
                    {
                        shieldFollowBoss.SetShieldSprite(bossShieldSprites[3]);
                    }

                    if (bossHealth == 1)
                    {
                        shieldFollowBoss.SetShieldSprite(bossShieldSprites[4]);
                    }

                    if (bossHealth == 0 && bossSpawn)
                    {
                        bossSpawn = false;
                        levelManager.SetScore(50);
                        Destroy(boss);
                        StartCoroutine(EndLevel());
                    }
                    break;
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
        else if (bossSpawn && atFirstBossPosition)
        {
            SetBossSpellCast();
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
        isCurrentlyCasting = false;
        SetBossSpellCast();
    }

    public int GetBossHealth() 
    {
        return bossHealth;
    }
 
    public bool GetBossSpawn()
    {
        return bossSpawn;
    }

    public bool IsAtFirstPosition()
    {
        return atFirstBossPosition;
    }
    public Transform GetBossPosition()
    {
        return bossLocation;
    }

    private void SetBossSpellCast() // Randomly selects a spell for the boss to cast and sets the current sprite to reflect that.
    {

        int randomNumber = Random.Range(0, 7);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                if (randomNumber == 0 && !isCurrentlyCasting)
                {
                    currentSpell = bossSpellsBeingCast[0];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = true;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 1 && !isCurrentlyCasting)
                {
                    currentSpell = bossSpellsBeingCast[1];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = true;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 2 && !isCurrentlyCasting)
                {
                    currentSpell = bossSpellsBeingCast[2];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = true;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 3 && !isCurrentlyCasting)
                {
                    currentSpell = bossSpellsBeingCast[3];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = true;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }               
                break;

            case 2:
                if (randomNumber == 0 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[0];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = true;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 1 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[1];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = true;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 2 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[2];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = true;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 3 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[3];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = true;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 4 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[4];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = true;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 5 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[5];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = true;
                    isCastingSpell_7 = false;
                    isCurrentlyCasting = true;
                }

                else if (randomNumber == 6 && !isCurrentlyCasting)
                {
                    currentSpell = lv2_bossSpellsBeingCast[6];
                    bossSpellRenderer.sprite = currentSpell;
                    isCastingSpell_1 = false;
                    isCastingSpell_2 = false;
                    isCastingSpell_3 = false;
                    isCastingSpell_4 = false;
                    isCastingSpell_5 = false;
                    isCastingSpell_6 = false;
                    isCastingSpell_7 = true;
                    isCurrentlyCasting = true;
                }
                break;
    }
    }

    public bool GetIsCurrentlyCasting() // May not need this
    {
        return isCurrentlyCasting;
    }

    public bool IsCastingSpell_1()
    {
        return isCastingSpell_1;
    }

    public bool IsCastingSpell_2()
    {
        return isCastingSpell_2;
    }

    public bool IsCastingSpell_3()
    {
        return isCastingSpell_3;
    }

    public bool IsCastingSpell_4()
    {
        return isCastingSpell_4;
    }

    public bool IsCastingSpell_5()
    {
        return isCastingSpell_5;
    }

    public bool IsCastingSpell_6()
    {
        return isCastingSpell_6;
    }

    public bool IsCastingSpell_7()
    {
        return isCastingSpell_7;
    }
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(0.3f);
        bossSpawn = false;
        levelManager.SetLevelComplete(true);
    }
}
