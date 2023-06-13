using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    public int maxJumps = 2;
    public int jumpCount = 0;
    bool grounded = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        GetComponent<Rigidbody2D>().velocity = velocity;
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
            //GetComponent<SpriteRenderer>().flipX = false;
            Vector3 s = transform.localScale;
            s.x = 1;
            transform.localScale = s;
        }
        else if (x < 0)
        {
            Vector3 s = transform.localScale;
            s.x = -1;
            transform.localScale = s;
            //GetComponent<SpriteRenderer>().flipX = true;
            //GameObject.Find("Flash Light").GetComponent
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
        }
    }
}
