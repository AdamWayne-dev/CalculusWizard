using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpellCast : MonoBehaviour
{
    SpawnWaves spawnwaves;
    [SerializeField] Transform bossPrefab;
    [SerializeField] GameObject bossSpellPage;
    LevelManager levelManager;
    private bool hasSpawned;
    private bool isLevelComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            bossSpellPage.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3) 
        {
            bossSpellPage.SetActive(true);
        }
        spawnwaves = FindObjectOfType<SpawnWaves>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
            isLevelComplete = levelManager.GetLevelComplete();     
            hasSpawned = spawnwaves.GetBossSpawn();
            if (hasSpawned && !isLevelComplete)
            {
                transform.position = spawnwaves.GetBossPosition().position + new Vector3(0, 3.5f, 0);
            }
        
    }
}
