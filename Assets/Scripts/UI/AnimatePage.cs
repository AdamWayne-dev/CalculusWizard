using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePage : MonoBehaviour
{
    FireSpells fireSpells;
    LevelLoader levelLoader;
    bool isPaused;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    private bool spellExists;

    private void Start()
    {
        fireSpells = FindObjectOfType<FireSpells>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    void Update()
    {
        spellExists = fireSpells.GetSpellExists();
        AnimatePages();
        isPaused = levelLoader.GetPausedStatus();
    }

    private void AnimatePages() // Animates the pages of the tome when the spell is changed.
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetAxisRaw("Mouse ScrollWheel") > 0f) && !spellExists && !isPaused)
        {
            animator.Play("PageTurnAnimation");
            audioSource.pitch = Random.Range(0.65f, 0.8f);
            audioSource.Play();
        }

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetAxisRaw("Mouse ScrollWheel") < 0f) && !spellExists && !isPaused)
        {
            animator.Play("PageTurnAnimation");
            audioSource.pitch = Random.Range(0.65f, 0.8f);
            audioSource.Play();
        }
        
    }
}
