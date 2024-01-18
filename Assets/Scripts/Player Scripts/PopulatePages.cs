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
    SpawnWaves spawnWaves;

    [SerializeField] SpriteRenderer leftPage;
    [SerializeField] SpriteRenderer rightPage;
    [SerializeField] Sprite[] lv1_Spells;
    [SerializeField] Sprite[] lv2_Spells;
    [SerializeField] Sprite[] lv2_poolOfSpells;
    [SerializeField] Sprite[] lv3_Spells;
    [SerializeField] Sprite[] lv3_poolOfSpells;

    private Sprite[] lv2_enemySprite;
    private Sprite[] lv3_enemySprite;

    public int[] spellIndexList;
    private bool[] spellsCollected;
    private bool[] lv2_spellsCollected;
    private bool[] lv3_spellsCollected; 
    private int spellIndex;
    private int lv2_spellIndex;
    private int lv3_spellIndex;
    private bool spellExists;
    private bool lv2_spellsPopulated;
    private bool lv3_spellsPopulated;



    void Start()
    {
        spawnWaves = FindObjectOfType<SpawnWaves>();
        lv2_spellsPopulated = false;
        lv3_spellsPopulated = false;
        spellsCollected = new bool[4];
        lv2_spellsCollected = new bool[7];
        lv2_Spells = new Sprite[7];
        lv3_spellsCollected = new bool[7];
        lv3_Spells = new Sprite[7];
        collideWithEnemy = FindObjectOfType<CollideWithEnemy>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
        Populate_Lv2_Spells();
        Populate_Lv3_Spells();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            lv2_enemySprite = spawnWaves.GetSprites();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            lv3_enemySprite = spawnWaves.GetSprites();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spellIndex = cycleSpells.GetSpellIndex();
        lv2_spellIndex = cycleSpells.GetSpellIndex();
        lv3_spellIndex = cycleSpells.GetSpellIndex();
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
                switch (lv2_spellIndex)
                {
                    case 0:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];

                        break;

                    case 1:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];

                        break;

                    case 2:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];

                        break;

                    case 3:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];

                        break;

                    case 4:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];
                        break;

                    case 5:
                        leftPage.sprite= lv2_poolOfSpells[spellIndex];
                        break;

                    case 6:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];
                        break;

                    case 7:
                        leftPage.sprite = lv2_poolOfSpells[spellIndex];
                        break;
                }
                break;
            case 3:
                switch (lv3_spellIndex)
                {
                    case 0:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];

                        break;

                    case 1:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];

                        break;

                    case 2:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];

                        break;

                    case 3:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];

                        break;

                    case 4:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];
                        break;

                    case 5:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];
                        break;

                    case 6:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];
                        break;

                    case 7:
                        leftPage.sprite = lv3_poolOfSpells[spellIndex];
                        break;
                }
                break;
        }
    }

    public void DisplayRightPage() // Checks to see if the page has been collected, and if it hasnt - displays the page once collected.
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
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
                break;
            case 2:
                switch (lv2_spellIndex)
                {
                    case 0:
                        if (lv2_spellsCollected[0])
                        {
                            rightPage.sprite = lv2_enemySprite[0];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 1:
                        if (lv2_spellsCollected[1])
                        {
                            rightPage.sprite = lv2_enemySprite[1];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 2:
                        if (lv2_spellsCollected[2])
                        {
                            rightPage.sprite = lv2_enemySprite[2];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 3:
                        if (lv2_spellsCollected[3])
                        {
                            rightPage.sprite = lv2_enemySprite[3];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 4:
                        if (lv2_spellsCollected[4])
                        {
                            rightPage.sprite = lv2_enemySprite[4];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 5:
                        if (lv2_spellsCollected[5])
                        {
                            rightPage.sprite = lv2_enemySprite[5];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 6:
                        if (lv2_spellsCollected[6])
                        {
                            rightPage.sprite = lv2_enemySprite[6];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                }
                break;
            case 3:
                switch (lv3_spellIndex)
                {
                    case 0:
                        if (lv3_spellsCollected[0])
                        {
                            rightPage.sprite = lv3_enemySprite[0];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 1:
                        if (lv3_spellsCollected[1])
                        {
                            rightPage.sprite = lv3_enemySprite[1];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 2:
                        if (lv3_spellsCollected[2])
                        {
                            rightPage.sprite = lv3_enemySprite[2];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 3:
                        if (lv3_spellsCollected[3])
                        {
                            rightPage.sprite = lv3_enemySprite[3];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 4:
                        if (lv3_spellsCollected[4])
                        {
                            rightPage.sprite = lv3_enemySprite[4];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 5:
                        if (lv3_spellsCollected[5])
                        {
                            rightPage.sprite = lv3_enemySprite[5];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                    case 6:
                        if (lv3_spellsCollected[6])
                        {
                            rightPage.sprite = lv3_enemySprite[6];
                        }
                        else
                        {
                            rightPage.sprite = null;
                        }
                        break;

                }
                break;
        }
    }

    public void SetSpellsCollected(int value, bool state)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                spellsCollected[value] = state;
                break;

            case 2:
                lv2_spellsCollected[value] = state;
                break;

            case 3:
                lv3_spellsCollected[value] = state;
                break;
        }

            
    }

    public bool GetSpellsCollected(int value)
    {
        return spellsCollected[value];
    }

    public bool Get_Lv2_SpellsCollected(int value)
    {
        return lv2_spellsCollected[value];
    }

    public bool Get_Lv3_SpellsCollected(int value)
    {
        return lv3_spellsCollected[value];
    }
    private void Populate_Lv2_Spells()
    {
        
        if (!lv2_spellsPopulated )
        {
            
            for (int i = 0; i < lv2_Spells.Length; i++)
            {
                lv2_Spells[i] = lv2_poolOfSpells[i];
            }
            lv2_spellsPopulated = true;
            
        }
    } 

    private void Populate_Lv3_Spells()
    {
        if (!lv3_spellsPopulated)
        {

            for (int i = 0; i < lv3_Spells.Length; i++)
            {
                lv3_Spells[i] = lv3_poolOfSpells[i];
            }
            lv3_spellsPopulated = true;

        }
    }
}
