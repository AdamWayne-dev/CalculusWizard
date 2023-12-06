using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health = 3;

    void Update()
    {
        CheckHealth();
    }

    public int GetHealth()
    {
        return health;
    }

    public void takeDamage(int damage) // rudimentary damage system. Allows for other scripts to damage player.
    {
        health -= damage;
    }

    private void CheckHealth() // Checks to see if health is at or below zero and if so, destroying the player.
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
