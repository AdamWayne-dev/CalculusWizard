using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private FireSpells fireSpell;
    private PlayerStats playerstats;
    private Rigidbody2D enemyRb;

    [SerializeField] float moveSpeed = 3f;
    void Start()
    {
        fireSpell = FindObjectOfType<FireSpells>();
        playerstats = FindObjectOfType<PlayerStats>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * (-moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerstats.takeDamage(1);
            gameObject.SetActive(false);
        }

        if (collision.tag == "FireSpell")
        {
            fireSpell.SetSpellExists(false);
            Destroy(collision.gameObject);
        }
    }
}
