using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 4.0f;
    public float stopDistance = 5f;
    public bool stopNear = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
    player.position.y - transform.position.y);
        if (stopNear == false)
        {
            Chase();
        }
        if (stopNear == true && chaseDirection.magnitude >= stopDistance)
        {
            Chase();
        }
        else
        {

        }
        

    }
    void Chase()
    {
        
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        chaseDirection.Normalize();
        //transform.up = chaseDirection;
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
