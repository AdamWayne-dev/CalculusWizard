using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawnZone : MonoBehaviour
{
    SpawnWaves spawnwaves;
    FireBossSpells fireBossSpells;
    private void Start()
    {
        spawnwaves = FindObjectOfType<SpawnWaves>();
        fireBossSpells = FindObjectOfType<FireBossSpells>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BossSpell")
        {       
            collision.enabled = false;
        }

        else
        {
            spawnwaves.SetHasSpawned(false);
            Destroy(collision.gameObject);
        }
        

    }
}
