using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWaywardSpells : MonoBehaviour
{
    FireSpells fireSpell;
    private void Start()
    {
        fireSpell = FindObjectOfType<FireSpells>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision) // Detects collision with the firespell and removes it if it leaves the play area (hits the border).
    {
        if (collision.tag == "FireSpell")
        {
            fireSpell.SetSpellExists(false); // This sets the firespell to false to enable the player to fire again.
            Destroy(collision.gameObject);
        }
    }
}
