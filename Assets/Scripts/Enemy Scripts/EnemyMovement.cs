using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private FireSpells fireSpell;
    private PlayerStats playerstats;
    private SpawnWaves spawnWaves;
     
    

    [SerializeField] float moveSpeed = 3f;
    void Start()
    {
        fireSpell = FindObjectOfType<FireSpells>();
        playerstats = FindObjectOfType<PlayerStats>();
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * (-moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerstats.takeDamage(1);
            spawnWaves.SetHasSpawned(false);
            gameObject.SetActive(false);
        }  
    }

  
}
