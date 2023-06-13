using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("x", GetComponent<Rigidbody2D>().velocity.x);
        animator.SetFloat("y", GetComponent<Rigidbody2D>().velocity.y);
    }
}
