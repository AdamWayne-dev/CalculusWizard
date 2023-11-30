using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithEnemy : MonoBehaviour
{

    private int spellIndex;
    CycleSpells cycleSpells;
    FireSpells fireSpells;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject spellBoof;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
    }
    void Update()
    {
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
                    fireSpells.SetSpellExists(false);
                    Destroy(collision.gameObject);
                    spriteRenderer.enabled = false;
                    StartCoroutine(SpellBoofDelay());                 
                }

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
                    fireSpells.SetSpellExists(false);
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
                    fireSpells.SetSpellExists(false);
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
                    fireSpells.SetSpellExists(false);
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
