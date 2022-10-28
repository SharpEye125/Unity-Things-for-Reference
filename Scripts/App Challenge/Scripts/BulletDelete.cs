using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    public float timer = 0;
    public float bulletLifetime = 10;
    public bool lifetimeDestroy;
    public bool contactDestroy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
        //Animator animator = GetComponent<Animator>();
        //animator.SetFloat("x", GetComponent<Rigidbody2D>().velocity.x);
        //animator.SetFloat("y", GetComponent<Rigidbody2D>().velocity.y);
        if (lifetimeDestroy == true)
        {
            timer += Time.deltaTime;
            if (timer >= bulletLifetime)
            {
                timer = 0;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (contactDestroy == true)
        {

        }
    }
}
