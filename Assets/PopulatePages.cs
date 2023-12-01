using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulatePages : MonoBehaviour
{
    CycleSpells cycleSpells;
    CollideWithEnemy collideWithEnemy;
    FireSpells fireSpells;

    [SerializeField] SpriteRenderer leftPage;
    [SerializeField] SpriteRenderer rightPage;
    [SerializeField] Sprite[] spells;

    private bool[] spellsCollected;
    private int spellIndex;
    private bool spellExists;
    
    void Start()
    {
        spellsCollected = new bool[4];
        collideWithEnemy = FindObjectOfType<CollideWithEnemy>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
    }

    // Update is called once per frame
    void Update()
    {
        spellIndex = cycleSpells.GetSpellIndex();
        spellExists = fireSpells.GetSpellExists();
        DisplayLeftPage();
        DisplayRightPage();
    }

    private void DisplayLeftPage() // Displays the current spell selected on the left page
    {
    
        switch (spellIndex)
        {
            case 0:
                leftPage.sprite = spells[spellIndex];
                
                break;

            case 1:
                leftPage.sprite = spells[spellIndex];
                
                break;

            case 2:
                leftPage.sprite = spells[spellIndex];
                
                break;

            case 3:
                leftPage.sprite = spells[spellIndex];
                
                break;
        }
        
    }

    public void DisplayRightPage() // Checks to see if the page has been collected, and if it hasnt - displays the page once collected.
    {
        switch (spellIndex)
        {
            case 0:
                if (spellsCollected[2])
                {
                    rightPage.sprite = spells[2];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 1:
                if (spellsCollected[0])
                {
                    rightPage.sprite = spells[0];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 2:
                if (spellsCollected[3])
                {
                    rightPage.sprite = spells[3];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 3:
                if (spellsCollected[1])
                {
                    rightPage.sprite = spells[1];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;
        }
        
    }

    public void SetSpellsCollected(int value, bool state)
    {
        spellsCollected[value] = state;
    }

    public bool GetSpellsCollected(int value)
    {
        return spellsCollected[value];
    }
    
}
