using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopulatePages : MonoBehaviour
{
    CycleSpells cycleSpells;
    CollideWithEnemy collideWithEnemy;
    FireSpells fireSpells;

    [SerializeField] SpriteRenderer leftPage;
    [SerializeField] SpriteRenderer rightPage;
    [SerializeField] Sprite[] lv1_Spells;
    [SerializeField] Sprite[] lv2_Spells;
    [SerializeField] Sprite[] lv2_poolOfSpells;
    [SerializeField] List<Sprite> lv2_temp_spellpool;
    [SerializeField] Sprite[] lv3_Spells;
    [SerializeField] Sprite[] lv3_poolOfSpells;

    private bool[] spellsCollected;
    private int spellIndex;
    private bool spellExists;
    private bool lv2_spellsPopulated;
    private bool lv2_tempSpellsPopulated;

    
    void Start()
    {
        lv2_spellsPopulated = false;
        lv2_tempSpellsPopulated = false;
        spellsCollected = new bool[4];
        lv2_Spells = new Sprite[4];
        lv2_temp_spellpool = new List<Sprite>();
        collideWithEnemy = FindObjectOfType<CollideWithEnemy>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
        Populate_Temp_Lv2Spells_List();
        Populate_Lv2_Spells();
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
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                switch (spellIndex)
                {
                    case 0:
                        leftPage.sprite = lv1_Spells[spellIndex];

                        break;

                    case 1:
                        leftPage.sprite = lv1_Spells[spellIndex];

                        break;

                    case 2:
                        leftPage.sprite = lv1_Spells[spellIndex];

                        break;

                    case 3:
                        leftPage.sprite = lv1_Spells[spellIndex];

                        break;
                }
                break;
            case 2:
                switch (spellIndex)
                {
                    case 0:
                        leftPage.sprite = lv2_Spells[spellIndex];

                        break;

                    case 1:
                        leftPage.sprite = lv2_Spells[spellIndex];

                        break;

                    case 2:
                        leftPage.sprite = lv2_Spells[spellIndex];

                        break;

                    case 3:
                        leftPage.sprite = lv2_Spells[spellIndex];

                        break;
                }
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
                    rightPage.sprite = lv1_Spells[2];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 1:
                if (spellsCollected[0])
                {
                    rightPage.sprite = lv1_Spells[0];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 2:
                if (spellsCollected[3])
                {
                    rightPage.sprite = lv1_Spells[3];
                }
                else
                {
                    rightPage.sprite = null;
                }
                break;

            case 3:
                if (spellsCollected[1])
                {
                    rightPage.sprite = lv1_Spells[1];
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

    private void Populate_Lv2_Spells()
    {
        
        if (!lv2_spellsPopulated && lv2_tempSpellsPopulated)
        {
            
            for (int i = 0; i < lv2_Spells.Length; i++)
            {
                int num = Random.Range(0, (lv2_temp_spellpool.Count - 1));
                Debug.Log(num);
                Debug.Log(lv2_temp_spellpool[num]);
                lv2_Spells[i] = lv2_temp_spellpool[num];
                lv2_temp_spellpool.RemoveAt(num);
            }
            lv2_spellsPopulated = true;
        }
    }
    
    private void Populate_Temp_Lv2Spells_List()
    {
        if (!lv2_tempSpellsPopulated)
        {
            for (int i = 0; i < lv2_poolOfSpells.Length; i++)
            {
                lv2_temp_spellpool.Add(lv2_poolOfSpells[i]);
            }
            lv2_tempSpellsPopulated = true;
        }
        Debug.Log("Temp spells allocated");
    }
}
