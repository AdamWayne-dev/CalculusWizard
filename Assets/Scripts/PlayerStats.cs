using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    public int GetHealth()
    {
        return health;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
