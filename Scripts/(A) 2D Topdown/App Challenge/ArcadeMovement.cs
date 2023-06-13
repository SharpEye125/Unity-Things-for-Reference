using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMovement : MonoBehaviour
{
    public float wel;
    public int moveSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, moveSpeed));
            vel();
            return;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -moveSpeed));
            vel();
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0));
            vel();
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed, 0));
            vel();
            return;
        }
        vel();
    }

    void Update()
    {
        
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
