using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private bool hasCollidedTop = false;
    private bool hasCollidedBottom = false;
    [SerializeField] float moveSpeed = 6f;

    PlayerStats playerStats;


    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement() // A basic up & down movement mechanic
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !hasCollidedTop)
        {
            transform.position += transform.up * (moveSpeed * Time.deltaTime);
        }

        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !hasCollidedBottom)
        {
            transform.position += transform.up * (-moveSpeed * Time.deltaTime);
        }
    }
#region Collisions
    /*
        This is a basic collision checking system that will set a bolean to true if the player collides with the upper or lower collision objects.
     */
    private void OnTriggerEnter2D(Collider2D collision) // Checks for collisions on both the 'CollideZoneTop' and 'CollideZoneBottom'
    {
        if (collision.tag == "CollideZoneTop")
        {
            hasCollidedTop = true;
            
        }

        if (collision.tag == "CollideZoneBottom")
        {
            hasCollidedBottom = true;
           
        }

        if (collision.tag == "BossSpell")
        {
            playerStats.takeDamage(1);    
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Resets the boolean of each collision check to enable movement again. 
    {

        if (collision.tag == "CollideZoneTop")
        {
            hasCollidedTop = false;

        }

        if (collision.tag == "CollideZoneBottom")
        {
            hasCollidedBottom = false;

        }
    }
    #endregion
}
