using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawnZone : MonoBehaviour
{
    SpawnWaves spawnwaves;

    private void Start()
    {
        spawnwaves = FindObjectOfType<SpawnWaves>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnwaves.SetHasSpawned(false);
        Destroy(collision.gameObject);

    }
}
