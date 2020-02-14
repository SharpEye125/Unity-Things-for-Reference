using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;
    public float moveX = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX  * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if(Input.GetButtonDown("Jump") && jumpCount < maxJumps)//&& grounded)
        {
            Jump();
            jumpCount++;
        }
        float x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);
        if (moveX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if (moveX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Jump()
    {
        if (jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(0f, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            jumpCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            //transform.eulerAngles = new Vector3(0, 0, 0);
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            anim.SetBool("grounded", grounded);
        }
    }
    public void MoveLeft()
    {
        moveX = -1;
    }
    
    public void MoveRight()
    {
        moveX = 1;
    }
    public void StopMove()
    {
        moveX = 0;
    }
}
