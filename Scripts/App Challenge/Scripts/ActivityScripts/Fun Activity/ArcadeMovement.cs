using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMovement : MonoBehaviour
{
    public float wel;
    public int moveSpeed = 10;
    Vector2 rightDir;
    Vector2 upDir;
    Vector2 downDir;
    Vector2 leftDir;
    Animator anim;
    public bool sploosh;
    public GameObject vfx;
    public float dur;
    public bool check;


    // Start is called before the first frame update
    void Start()
    {
        rightDir = new Vector2(0, 0);
        upDir = new Vector2(0, 90);
        downDir = new Vector2(0, -90);
        leftDir = new Vector2(0, 0);
        anim = GetComponent<Animator>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            joystick.JS2 = 1;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, moveSpeed));
            vel();
            transform.right = upDir;
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isMoving", true);
            //return;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            joystick.JS2 = 3;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -moveSpeed));
            vel();
            transform.right = downDir;
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isMoving", true);
            //return;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            joystick.JS2 = 2;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0));
            vel();
            transform.right = rightDir;
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isMoving", true);
            //return;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            joystick.JS2 = 4;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed, 0));
            vel();
            transform.right = leftDir;
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isMoving", true);
            //return;
        }
        else
        {
            joystick.JS2 = 0;
            anim.SetBool("isMoving", false);
        }
        vel();
        
        
    }


    void Update()
    {
        if (sploosh == true)
        {
            if(check == false)
                {
                GameObject explosion = Instantiate(vfx, transform.position, transform.rotation);
                Destroy(explosion, dur);
                check = true;
            }
        }
        else
        {
            check = false;
        }
    }
    public void vel()
    {
        Vector2 newVel = GetComponent<Rigidbody2D>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -moveSpeed, moveSpeed);
        GetComponent<Rigidbody2D>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody2D>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -moveSpeed, moveSpeed);
        GetComponent<Rigidbody2D>().velocity = newfall;
    }
}
