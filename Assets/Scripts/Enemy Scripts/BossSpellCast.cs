using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellCast : MonoBehaviour
{
    SpawnWaves spawnwaves;
    [SerializeField] Transform bossPrefab;

    LevelManager levelManager;
    private bool hasSpawned;
    private bool isLevelComplete;
    // Start is called before the first frame update
    void Start()
    {
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
