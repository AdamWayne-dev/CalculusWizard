using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpells : MonoBehaviour
{
    [SerializeField] GameObject fireSpellPrefab;
    [SerializeField] CycleSpells cycleSpells;
    [SerializeField] float fireSpeed = 7f;

    GameObject spell;
    private bool spellExists = false;

    void Update()
    {
        SetCurrentSpell();
        FireSpell();
    }

    private void FireSpell() // Basic system for firing a spell. Creates a delay by only allowing for one spell per time, disabling the spamming of spells.
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spellExists)
        {
            spellExists = true;
            spell = Instantiate(fireSpellPrefab, transform.position, Quaternion.identity);
            // Disable player movement while spells on cooldown?
        }
        if (spellExists)
        {
            spell.transform.position += spell.transform.right * (fireSpeed * Time.deltaTime);
        }
        
    }

    public void SetSpellExists(bool setState) // allows for other scripts to set the state of the spell (after collisions).
    {
        spellExists = setState;
    }

    public void SetCurrentSpell() // Sets te current spell from the cyclespells script.
    {
        fireSpellPrefab = cycleSpells.GetCurrentSpell();
    }
}
