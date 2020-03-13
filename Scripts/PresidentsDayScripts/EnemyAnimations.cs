using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Rigidbody2D rb;
    //public GameObject components;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("x", rb.velocity.x);
        animator.SetFloat("y", rb.velocity.y);
    }
}
