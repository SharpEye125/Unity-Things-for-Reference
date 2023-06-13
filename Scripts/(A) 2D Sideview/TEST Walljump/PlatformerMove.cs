using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public float fallSpeed = 0.3f;
    public float jumpAway = 4f;
    public float ogGravity = 1;
    public int maxJumps = 2;
    public int jumpCount = 0;
    bool grounded = false;
    bool sliding = false; 
    //bool right;
    Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ogGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && sliding)
        {
            SlideJump();
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)// && grounded)
        {
            Jump();
        }
        anim.SetBool("grounded", grounded);
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Vector3 s = transform.localScale;
            //s.x = 1;
            //transform.localScale = s;
            
        }
        else if (x < 0)
        {
            //Vector3 s = transform.localScale;
            //s.x = -1;
            //transform.localScale = s;
            
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void Jump()
    {
        if (!grounded)
        {
            jumpCount++;
        }
        GetComponent<Rigidbody2D>().AddForce
            (new Vector2(0, 100 * jumpSpeed));
        rb.velocity = new Vector2(0f, 0);
    }
    public void Slide()
    {
        if (rb.velocity.y < 0.5f)
        {
            rb.gravityScale = fallSpeed;
            rb.velocity = new Vector2(0f, fallSpeed);
        }
        sliding = true;
        anim.SetBool ("sliding", sliding);
    }
    public void SlideJump()
    {
        rb.velocity = new Vector2(0f, 0);
        GetComponent<Rigidbody2D>().AddForce
            (new Vector2(100 * jumpAway, 100 * jumpSpeed));
        sliding = false;
        rb.gravityScale = ogGravity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            jumpCount = 0;
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            jumpCount++;
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            jumpCount = 0;
            grounded = true;
            sliding = true;
            anim.SetTrigger("slideJump");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts[0].normal == new Vector2(1, 0) && grounded == false)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Slide();
        }
        else if (collision.contacts[0].normal == new Vector2(-1, 0) && grounded == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Slide();
        }
    }
}
