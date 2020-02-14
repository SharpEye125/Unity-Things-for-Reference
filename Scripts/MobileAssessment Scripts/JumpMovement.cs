using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    //Jump/Y Variables
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 1;
    bool chargingJump = false;
    public float chargeSpeed = 0.2f;
    public float maxJumpHeight = 5;
    public float maxFallSpeed = -20f;
    // public float minJump = 1;

    public Joystick joystick;
    public float xJoystickSensitivity = 0.2f;
    public float yJoystickSensitivity = 0.5f;

    // X axis variables


    public float moveSpeed = 0.1f;
    public float maxSpeed = 1;
    bool movingLeft = false;
    bool movingRight = false;

    Animator anim;
    Rigidbody2D rb;

    
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        //velocity.x = joystick.Horizontal * moveSpeed;
        if (joystick.Horizontal >= xJoystickSensitivity && grounded == false)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x += moveSpeed;
            if (velocity.x > maxSpeed)
            {
                velocity.x = maxSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else if (joystick.Horizontal <= -xJoystickSensitivity && grounded == false)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x += -moveSpeed;
            if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(0f, maxFallSpeed);
        }
        if (jumpHeight > maxJumpHeight)
        {
            jumpHeight = maxJumpHeight;
        }
        if (chargingJump == true)
        {
            jumpHeight += Time.deltaTime *chargeSpeed;
            anim.SetFloat("JumpHeight", jumpHeight);
            //jumpHeight += chargeSpeed;
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

    public void ChargeJump()
    {
        chargingJump = true;
        anim.SetBool("ChargingJump", chargingJump);
    }
    public void Jump()
    {
        chargingJump = false;
        anim.SetBool("ChargingJump", chargingJump);
        anim.SetTrigger("Jump");
        if (jumpCount < maxJumps || grounded == true)
        {
            rb.velocity = new Vector2(0f, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpHeight));
            jumpCount++;
        }
        jumpHeight = 0;
        anim.SetFloat("JumpHeight", jumpHeight);
    }

    public void MoveRight()
    {
        movingRight = true;
    }
    public void MoveLeft()
    {
        movingLeft = true;
    }
    public void DisableBools()
    {
        movingRight = false;
        movingLeft = false;
    }


    void Temp()
    {
        if (joystick.Horizontal >= xJoystickSensitivity && grounded == false)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x += moveSpeed;
            if (velocity.x > maxSpeed)
            {
                velocity.x = maxSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else if (joystick.Horizontal <= -xJoystickSensitivity && grounded == false)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x += -moveSpeed;
            if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

    }
}
