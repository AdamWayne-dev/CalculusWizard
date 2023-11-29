using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePage : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Update()
    {
        AnimatePages();
    }

    private void AnimatePages() // Animates the pages of the tome when the spell is changed.
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("PageTurnAnimation");
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.Play("PageTurnAnimation");
        }
        
    }
}
