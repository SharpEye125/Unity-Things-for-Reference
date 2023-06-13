using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float wel;
    public int moveSpeed = 10;
    void Start()
    {

    }
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        wel += Time.deltaTime;

        if (wel >= 0.01f)
        {
            wel = 0;
            if (Input.GetKey(KeyCode.W))

            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, moveSpeed));
            }
            if (Input.GetKey(KeyCode.S))

            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -moveSpeed));

            }
            if (Input.GetKey(KeyCode.D))

            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0));

            }
            if (Input.GetKey(KeyCode.A))

            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed, 0));

            }
            if (Input.GetKey(KeyCode.Space))

            {
                //moveSpeed += 1;

            }
            vel();
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
