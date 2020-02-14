using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveWithPlayer : MonoBehaviour
{
    //public float speed = 1;
    private Rigidbody2D rb;
    float y;
    GameObject player;
    float bulletspeed;
    Vector2 velocity;
    void Start()
    {
        float y = 1;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        velocity = player.GetComponent<Rigidbody2D>().velocity;
        //GetComponent<Rigidbody2D>().velocity = (transform.up * speed);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, velocity.y);
    }
}
