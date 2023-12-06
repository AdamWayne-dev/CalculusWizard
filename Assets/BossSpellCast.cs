using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellCast : MonoBehaviour
{
    SpawnWaves spawnwaves;
    [SerializeField] Transform bossPrefab;
    private bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        spawnwaves = FindObjectOfType<SpawnWaves>();

    }

    // Update is called once per frame
    void Update()
    {
        hasSpawned = spawnwaves.GetBossSpawn();
        if (hasSpawned)
        {
            transform.position = spawnwaves.GetBossPosition().position + new Vector3(0, 3.5f, 0);
        }
    }
}
