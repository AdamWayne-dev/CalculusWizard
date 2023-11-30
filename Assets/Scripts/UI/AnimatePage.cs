using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePage : MonoBehaviour
{
    FireSpells fireSpells;
    [SerializeField] Animator animator;

    private bool spellExists;

    private void Start()
    {
        fireSpells = FindObjectOfType<FireSpells>();
    }
    void Update()
    {
        spellExists = fireSpells.GetSpellExists();
        AnimatePages();
    }

    private void AnimatePages() // Animates the pages of the tome when the spell is changed.
    {
        if (Input.GetKeyDown(KeyCode.E) && !spellExists)
        {
            animator.Play("PageTurnAnimation");
            
        }

        if (Input.GetKeyDown(KeyCode.Q) && !spellExists)
        {
            animator.Play("PageTurnAnimation");
        }
        
    }
}
