using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FireBossSpells : MonoBehaviour
{
    SpawnWaves spawnwaves;
    [SerializeField] GameObject bossSpellPrefab;
    [SerializeField] Transform firePosition;
    [SerializeField] float fireSpeed = 7f;
    [SerializeField] float fireDelay = 4f;

    GameObject spell;
    private bool bossInPosition;
    private bool bossSpawn;
    private bool spellExists;
    private float timer;

    private void Start()
    {
        timer = 3f;
        spawnwaves = FindObjectOfType<SpawnWaves>();
    }

    void Update()
    {
        bossInPosition = spawnwaves.IsAtFirstPosition();
        bossSpawn = spawnwaves.GetBossSpawn();
        if (bossInPosition && bossSpawn)
        {
            CountDownTimer();
            if (timer <= 0)
            {
                spellExists = true;
                spell = Instantiate(bossSpellPrefab, firePosition, false);
                timer = 3f;
            }
            if (spellExists)
            {
                spell.transform.position -= spell.transform.right * (fireSpeed * Time.deltaTime);
            }
        }
    }
      
    private void CountDownTimer()
    {
        timer = timer - (1 * Time.deltaTime);
    }
    
    public void SetSpellExists(bool state)
    {
        spellExists = state;
    }
}
