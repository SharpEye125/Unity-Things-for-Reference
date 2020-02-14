using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick joystick;
    public float xJoystickSensitivity = 0.2f;
    public float yJoystickSensitivity = 0.5f;

    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;
    float moveX = 0;
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

        if (joystick.Horizontal >= xJoystickSensitivity)
        {
            //velocity.x = moveSpeed;
            moveX = 1;
        }
        else if (joystick.Horizontal <= -xJoystickSensitivity)
        {
            //velocity.x = -moveSpeed;
            moveX = -1;
        }
        else
        {
            //velocity.x = 0;
            moveX = 0;
        }

        float verticalMove = joystick.Vertical;

        //velocity.x = joystick.Horizontal  * moveSpeed;
        velocity.x = moveX * moveSpeed;

        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps || verticalMove >= yJoystickSensitivity) //|| joystick.Vertical > 0)//&& grounded)
        {
            Jump();
            jumpCount++;
        }
        float x = Input.GetAxisRaw("Horizontal");
        if(x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        if(velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if (x < 0)
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
            transform.eulerAngles = new Vector3(0, 0, 0);
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
