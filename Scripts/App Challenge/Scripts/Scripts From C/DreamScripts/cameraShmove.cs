using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShmove : MonoBehaviour
{
    public float spd;
    public float btimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVel = gameObject.GetComponent<Rigidbody2D>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -spd, spd);
        GetComponent<Rigidbody2D>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody2D>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -spd, spd);
        GetComponent<Rigidbody2D>().velocity = newfall;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 atpos = player.transform.position - transform.position;
        btimer += Time.deltaTime;
        if (btimer >= 0.01)
        {
            btimer = 0f;
            GetComponent<Rigidbody2D>().AddForce(atpos);
            Debug.DrawRay(transform.position, (atpos), Color.yellow, 0.25f);

        }
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.drag = 10 - Vector2.Distance(player.transform.position, transform.position) ;
        if (rb.drag>5)
        {
            rb.drag = 5;
        }
        if(rb.drag<1)
        {
            rb.drag = 1;
        }
    }
}