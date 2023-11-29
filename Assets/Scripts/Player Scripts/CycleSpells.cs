using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSpells : MonoBehaviour
{
    [SerializeField] GameObject[] spellPrefabs;
    private GameObject currentSpell;
    private int spellIndex = 0;

    private void Start()
    {
        currentSpell = spellPrefabs[0];
    }

    private void Update()
    {
        SpellCycle();
        SetSpell();
    }
    public GameObject GetCurrentSpell()
    { 
        return currentSpell;
    }

    public void SpellCycle() // cycle through the array of spells using 'E' to go forwards and 'Q' to go backwards.
    {   
        
        if (Input.GetKeyDown(KeyCode.E))
        {      
            spellIndex++;
            if (spellIndex == spellPrefabs.Length)
            {
                spellIndex = 0;
            }
                     
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            spellIndex--;
            if (spellIndex < 0)
            {
                spellIndex = spellPrefabs.Length - 1;
            }                  
           
        }
    }

    public void SetSpell()
    {
        currentSpell = spellPrefabs[spellIndex];
    }

    public int GetSpellIndex()
    {
        return spellIndex;
    }
}
