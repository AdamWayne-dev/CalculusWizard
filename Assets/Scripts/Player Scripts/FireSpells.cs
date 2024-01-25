using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using TMPro;
using UnityEngine.SceneManagement;

public class FireSpells : MonoBehaviour
{
    PopulatePages populatePages;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject fireSpellPrefab;
    [SerializeField] CycleSpells cycleSpells;
    [SerializeField] float fireSpeed = 7f;
                     TMP_Text pageText;
    [SerializeField] Sprite[] spellSprites;

    SpriteRenderer spellRenderer;
    GameObject spell;

    private int spellIndex;
    private bool spellExists = false;

    private void Start()
    {
        populatePages = FindObjectOfType<PopulatePages>();
    }
    void Update()
    {
        spellIndex = cycleSpells.GetSpellIndex();
        SetCurrentSpell();
        FireSpell();
    }

    private void FireSpell() // Basic system for firing a spell. Creates a delay by only allowing for one spell per time, disabling the spamming of spells.
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && !spellExists)
        {
            spellExists = true;
            audioSource.pitch = Random.Range(0.7f, 1f);
            audioSource.Play();
            spell = Instantiate(fireSpellPrefab, transform.position, Quaternion.identity);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                spellRenderer = spell.GetComponent<SpriteRenderer>();
                spellRenderer.sprite = spellSprites[spellIndex];
            }
            if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
            {
                pageText = spell.GetComponentInChildren<TMP_Text>();
                pageText.text = populatePages.GetLeftPageText();
            }
            
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

    public bool GetSpellExists() 
    { 
        return spellExists; 
    }
    public void SetCurrentSpell() // Sets the current spell from the cyclespells script.
    {
        fireSpellPrefab = cycleSpells.GetCurrentSpell();
    }

    
      
}
    

 
