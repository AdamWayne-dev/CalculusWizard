using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{

    private int spellIndex;
    CycleSpells cycleSpells;
    PopulatePages populate;
    FireSpells fireSpells;
    SpriteRenderer spriteRenderer;
    SpawnWaves spawnWaves;
    [SerializeField] GameObject spellBoof;

    private bool[] spellsCollected;

 
   
    
    private void Start()
    {
        spellsCollected = new bool[4];
        populate = FindObjectOfType<PopulatePages>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }
    void Update()
    {
        PopulateSpells();
    }

    private void PopulateSpells()
    {
        spellsCollected[0] = populate.GetSpellsCollected(0);
        spellsCollected[1] = populate.GetSpellsCollected(1);
        spellsCollected[2] = populate.GetSpellsCollected(2);
        spellsCollected[3] = populate.GetSpellsCollected(3);
        spellIndex = cycleSpells.GetSpellIndex();
    }

    private void OnTriggerEnter2D(Collider2D collision) /* Checks to see what "type" an enemy is and depending on which spell is selected, will either
                                                           Destroy the enemy or stun the player
                                                        */
        {
        switch (spellIndex)
        {
            case 0:
                if (collision.tag == "GreenEnemy")
                {
                    if (!spellsCollected[2])
                    {
                        populate.SetSpellsCollected(2, true);
                    }                  
                    fireSpells.SetSpellExists(false);
                    spawnWaves.SetHasSpawned(false);
                    Destroy(collision.gameObject);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());                 
                }

                // ADD BOSS HIT CHECK
                else
                {
                    // Add stun to player?
                    fireSpells.SetSpellExists(false);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());
                }

                break;

            case 1:
                if (collision.tag == "RedEnemy")
                {
                    if (!spellsCollected[0])
                    {
                        populate.SetSpellsCollected(0, true);
                    }
                    fireSpells.SetSpellExists(false);
                    spawnWaves.SetHasSpawned(false);
                    Destroy(collision.gameObject);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());                   
                }
                else
                {
                    // Add stun to player?
                    fireSpells.SetSpellExists(false);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());
                }
                break;

            case 2:
                if (collision.tag == "YellowEnemy")
                {
                    if (!spellsCollected[3])
                    {
                        populate.SetSpellsCollected(3, true);
                    }
                    fireSpells.SetSpellExists(false);
                    spawnWaves.SetHasSpawned(false);
                    Destroy(collision.gameObject);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());                   
                }
                else
                {
                    // Add stun to player?
                    fireSpells.SetSpellExists(false);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());
                }
                break;

            case 3:
                if (collision.tag == "BlueEnemy")
                {
                    if (!spellsCollected[1])
                    {
                        populate.SetSpellsCollected(1, true);
                    }
                    fireSpells.SetSpellExists(false);
                    spawnWaves.SetHasSpawned(false);
                    Destroy(collision.gameObject);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());
                }
                else
                {
                    // Add stun to player?
                    fireSpells.SetSpellExists(false);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());
                }
                break; 
        }
    }
    IEnumerator SpellBoofDelay()
    {
        GameObject spellEffect = Instantiate(spellBoof, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Destroy(spellEffect.gameObject);
        Destroy(gameObject);
    }
 
}
