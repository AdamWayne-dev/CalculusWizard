using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] SpriteRenderer healthSpriteRenderer;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite[] healthSprites;
    Color collideColour;
    Color normalColour;
    private int health = 3;

    private void Start()
    {
        collideColour = new Color(191, 70, 192 );
        normalColour = playerSpriteRenderer.material.color;
    }
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
        StartCoroutine(Flasher());
    }

    private void CheckHealth() // Checks to see if health is at or below zero and if so, destroying the player.
    {
        if (health >= 3)
        {
            healthSpriteRenderer.sprite = healthSprites[0];
        }

        else if (health == 2)
        {
            healthSpriteRenderer.sprite = healthSprites[1];
        }

        else if (health == 1)
        {
            healthSpriteRenderer.sprite = healthSprites[2];
        }

        else if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Flasher()
    {
        playerSpriteRenderer.material.color = collideColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = normalColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = collideColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = normalColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = collideColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = normalColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = collideColour;
        yield return new WaitForSeconds(.1f);
        playerSpriteRenderer.material.color = normalColour;
    }
}
