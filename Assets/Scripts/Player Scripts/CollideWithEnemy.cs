using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithEnemy : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private int spellIndex;
    LevelManager levelManager;
    CycleSpells cycleSpells;
    PopulatePages populate;
    FireSpells fireSpells;
    SpriteRenderer spriteRenderer;
    SpawnWaves spawnWaves;
    [SerializeField] GameObject spellBoof;

    private bool[] spellsCollected;
    public bool[] lv2_spellsCollected;

    private bool bossIsCastingSpell_0;
    private bool bossIsCastingSpell_1;
    private bool bossIsCastingSpell_2;
    private bool bossIsCastingSpell_3;
    private bool bossIsCastingSpell_4;
    private bool bossIsCastingSpell_5;
    private bool bossIsCastingSpell_6;
 
   
    
    private void Start()
    {         
        spellsCollected = new bool[4];
        lv2_spellsCollected = new bool[7];
        levelManager = FindObjectOfType<LevelManager>();
        populate = FindObjectOfType<PopulatePages>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cycleSpells = FindObjectOfType<CycleSpells>();
        fireSpells = FindObjectOfType<FireSpells>();
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }
    void Update()
    {
        PopulateSpells();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        { 
            Populate_Lv2_Spells();
        }
        CheckCastingStatus();
    }

    private void PopulateSpells()
    {
        spellsCollected[0] = populate.GetSpellsCollected(0);
        spellsCollected[1] = populate.GetSpellsCollected(1);
        spellsCollected[2] = populate.GetSpellsCollected(2);
        spellsCollected[3] = populate.GetSpellsCollected(3);
        spellIndex = cycleSpells.GetSpellIndex();
    }

    private void Populate_Lv2_Spells()
    {
        lv2_spellsCollected[0] = populate.Get_Lv2_SpellsCollected(0);
        lv2_spellsCollected[1] = populate.Get_Lv2_SpellsCollected(1);
        lv2_spellsCollected[2] = populate.Get_Lv2_SpellsCollected(2);
        lv2_spellsCollected[3] = populate.Get_Lv2_SpellsCollected(3);
        lv2_spellsCollected[4] = populate.Get_Lv2_SpellsCollected(4);
        lv2_spellsCollected[5] = populate.Get_Lv2_SpellsCollected(5);
        lv2_spellsCollected[6] = populate.Get_Lv2_SpellsCollected(6);

    }

    private void OnTriggerEnter2D(Collider2D collision) /* Checks to see what level it is and then what "type" an enemy is and depending on which spell is selected, will either
                                                           Destroy the enemy;
                                                        */
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
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
                        levelManager.SetScore(15);
                        Destroy(collision.gameObject);
                        spriteRenderer.enabled = false;
                        StartCoroutine(SpellBoofDelay());
                    }

                    else if (collision.tag == "Boss_Level_1")
                    {
                        Boss_Level_1_Check_Spell_2();
                    }

                    else
                    {

                        levelManager.SetScore(-5);
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
                        levelManager.SetScore(15);
                        Destroy(collision.gameObject);
                        spriteRenderer.enabled = false;
                        StartCoroutine(SpellBoofDelay());
                    }

                    else if (collision.tag == "Boss_Level_1")
                    {
                        Boss_Level_1_Check_Spell_0();
                    }

                    else
                    {

                        levelManager.SetScore(-5);
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
                        levelManager.SetScore(15);
                        Destroy(collision.gameObject);
                        spriteRenderer.enabled = false;
                        StartCoroutine(SpellBoofDelay());
                    }

                    else if (collision.tag == "Boss_Level_1")
                    {
                        Boss_Level_1_Check_Spell_3();
                    }

                    else
                    {

                        levelManager.SetScore(-5);
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
                        levelManager.SetScore(15);
                        Destroy(collision.gameObject);
                        spriteRenderer.enabled = false;
                        StartCoroutine(SpellBoofDelay());
                    }

                    else if (collision.tag == "Boss_Level_1")
                    {
                        Boss_Level_1_Check_Spell_1();
                    }

                    else
                    {

                        levelManager.SetScore(-5);
                        fireSpells.SetSpellExists(false);
                        spriteRenderer.enabled = false;
                        StartCoroutine(SpellBoofDelay());
                    }
                    break;
            }
                break;
            case 2:
                switch (spellIndex)
                {
                    case 0:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[0])
                            {
                                populate.SetSpellsCollected(0, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_0();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;
                    case 1:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[1])
                            {
                                populate.SetSpellsCollected(1, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_1();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;
                    case 2:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[2])
                            {
                                populate.SetSpellsCollected(2, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_2();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;
                    case 3:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[3])
                            {
                                populate.SetSpellsCollected(3, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_3();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;
                    case 4:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[4])
                            {
                                populate.SetSpellsCollected(4, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_4();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;

                    case 5:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[5])
                            {
                                populate.SetSpellsCollected(5, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_5();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;

                    case 6:
                        if (collision.tag == gameObject.tag)
                        {
                            if (!lv2_spellsCollected[6])
                            {
                                populate.SetSpellsCollected(6, true);
                            }
                            fireSpells.SetSpellExists(false);
                            spawnWaves.SetHasSpawned(false);
                            levelManager.SetScore(30);
                            Destroy(collision.gameObject);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }

                        else if (collision.tag == "Boss_Level_2")
                        {
                            Boss_Level_2_Check_Spell_6();
                        }

                        else
                        {

                            levelManager.SetScore(-10);
                            fireSpells.SetSpellExists(false);
                            spriteRenderer.enabled = false;
                            StartCoroutine(SpellBoofDelay());
                        }
                        break;
                }
                break;
    }
    }
    #region
    private void Boss_Level_1_Check_Spell_0()
    {
        if (bossIsCastingSpell_0)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(20);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-5);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }
    private void Boss_Level_1_Check_Spell_1()
    {
        if (bossIsCastingSpell_1)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(15);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-5);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }
    private void Boss_Level_1_Check_Spell_2()
    {
        if (bossIsCastingSpell_2)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(15);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-5);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_1_Check_Spell_3()
    {
        if (bossIsCastingSpell_3)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(15);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-5);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_0()
    {
        if (bossIsCastingSpell_0)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_1()
    {
        if (bossIsCastingSpell_1)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_2()
    {
        if (bossIsCastingSpell_2)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_3()
    {
        if (bossIsCastingSpell_3)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_4()
    {
        if (bossIsCastingSpell_4)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_5()
    {
        if (bossIsCastingSpell_5)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }

    private void Boss_Level_2_Check_Spell_6()
    {
        if (bossIsCastingSpell_6)
        {
            spawnWaves.DamageBoss();
            fireSpells.SetSpellExists(false);
            levelManager.SetScore(30);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }

        else
        {
            // Add stun to player?
            levelManager.SetScore(-10);
            fireSpells.SetSpellExists(false);
            spriteRenderer.enabled = false;
            StartCoroutine(SpellBoofDelay());
        }
    }
    #endregion
    IEnumerator SpellBoofDelay()
    {
        PlayAudioHit();
        GameObject spellEffect = Instantiate(spellBoof, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Destroy(spellEffect.gameObject);
        Destroy(gameObject);
    }
 

    private void CheckCastingStatus()
    {
        bossIsCastingSpell_0 = spawnWaves.IsCastingSpell_1();
        bossIsCastingSpell_1 = spawnWaves.IsCastingSpell_2();
        bossIsCastingSpell_2 = spawnWaves.IsCastingSpell_3();
        bossIsCastingSpell_3 = spawnWaves.IsCastingSpell_4();
        bossIsCastingSpell_4 = spawnWaves.IsCastingSpell_5();
        bossIsCastingSpell_5 = spawnWaves.IsCastingSpell_6();
        bossIsCastingSpell_6 = spawnWaves.IsCastingSpell_7();
    }  
    
    private void PlayAudioHit()
    {
        audioSource.pitch = Random.Range(0.7f, 1f);
        audioSource.Play();
    }
}
