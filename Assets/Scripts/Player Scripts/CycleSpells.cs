using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CycleSpells : MonoBehaviour
{
    FireSpells fireSpells;
    [SerializeField] GameObject[] spellPrefabs;
    [SerializeField] GameObject[] lvl_2_SpellPrefabs;
    [SerializeField] GameObject[] lvl_3_SpellPrefabs;
    private GameObject currentSpell;
    private int spellIndex = 0;
    private bool doesSpellExist;

    private void Start()
    {
        fireSpells = FindObjectOfType<FireSpells>();
        currentSpell = spellPrefabs[0];
    }

    private void Update()
    {

        doesSpellExist = fireSpells.GetSpellExists();
        SpellCycle();
        SetSpell();
    }
    public GameObject GetCurrentSpell()
    { 
        return currentSpell;
    }

    public void SpellCycle() // cycle through the array of spells using 'E' to go forwards and 'Q' to go backwards.
    {   
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
            if ((Input.GetKeyDown(KeyCode.E)|| Input.GetAxisRaw("Mouse ScrollWheel") > 0f) && !doesSpellExist)
            {      
                spellIndex++;
                if (spellIndex == spellPrefabs.Length)
                {
                    spellIndex = 0;
                }
                     
            }

            if ((Input.GetKeyDown(KeyCode.Q) || Input.GetAxisRaw("Mouse ScrollWheel") < 0f) && !doesSpellExist)
            {
                spellIndex--;
                if (spellIndex < 0)
                {
                    spellIndex = spellPrefabs.Length - 1;
                }                  
           
            }
                break;

            case 2:
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetAxisRaw("Mouse ScrollWheel") > 0f) && !doesSpellExist)
                {
                    spellIndex++;
                    if (spellIndex == lvl_2_SpellPrefabs.Length)
                    {
                        spellIndex = 0;
                    }
                }

                if ((Input.GetKeyDown(KeyCode.Q) || Input.GetAxisRaw("Mouse ScrollWheel") < 0f) && !doesSpellExist)
                {
                    spellIndex--;
                    if (spellIndex < 0)
                    {
                        spellIndex = lvl_2_SpellPrefabs.Length - 1;
                    }
                }
                break;

            case 3:
                if ((Input.GetKeyDown(KeyCode.E) || Input.GetAxisRaw("Mouse ScrollWheel") > 0f) && !doesSpellExist)
                {
                    spellIndex++;
                    if (spellIndex == lvl_3_SpellPrefabs.Length)
                    {
                        spellIndex = 0;
                    }
                }

                if ((Input.GetKeyDown(KeyCode.Q) || Input.GetAxisRaw("Mouse ScrollWheel") < 0f) && !doesSpellExist)
                {
                    spellIndex--;
                    if (spellIndex < 0)
                    {
                        spellIndex = lvl_3_SpellPrefabs.Length - 1;
                    }
                }
                break;
        }
    }

    public void SetSpell()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                currentSpell = spellPrefabs[spellIndex];
                break;

            case 2:
                currentSpell = lvl_2_SpellPrefabs[spellIndex];
                break;

            case 3:
                currentSpell = lvl_3_SpellPrefabs[spellIndex];
                break;
        }
    }

    public int GetSpellIndex()
    {
        return spellIndex;
    }
}
