using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed = 5f;
    public float bounceHeight = 1f;
    public int damage = 1;

    public float left = -0.01f;
    public float right = 0.01f;
    //public float gravity;
    //public float gravityMultiplier;
    Rigidbody2D rb;
    //public Vector2 velocity;
    // Start is called before the first frame update
    //public Animator Animator;
    void Start()
    {
        //Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        //gravity = rb.gravityScale;
        //rb.gravityScale = gravity * 2;
        //rb = GetComponent<Rigidbody2D>();
        //velocity = rb.velocity;
    } 

    // Update is called once per frame
    void Update()
    {
        //in case it falls off the map
        if (rb.velocity.y < -100)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Animator.SetTrigger("bounce");
        GetComponent<Rigidbody2D>().AddForce
                (new Vector2(0, 100 * bounceHeight));

        if (rb.velocity.x < speed && rb.velocity.x > right)
        {
            rb.velocity = new Vector2 (speed, 0f);
        }
        else if (rb.velocity.x < speed && rb.velocity.x < right)
        {
            rb.velocity = new Vector2(-speed, 0f);
        }

        //rb.gravityScale = gravity;
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        
    }

}
