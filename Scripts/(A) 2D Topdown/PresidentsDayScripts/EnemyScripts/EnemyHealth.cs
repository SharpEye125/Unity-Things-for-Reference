using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    PlayerHP playerHPThings;
    Transform player;
    public int enemyMoney = 1;
    public int maxEnemyHealth;
    public int enemyHealth = 5;
    public bool dropHealth = false;
    public GameObject health;

    void Start()
    {
        maxEnemyHealth = enemyHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHPThings = player.GetComponent<PlayerHP>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;
            if (enemyHealth < 1)
            {
                if (dropHealth != false)
                {
                    Instantiate(health, transform.position, Quaternion.identity);
                }
                playerHPThings.playerMoney += enemyMoney;
                Destroy(gameObject);
                
            }
        }
    }
}
