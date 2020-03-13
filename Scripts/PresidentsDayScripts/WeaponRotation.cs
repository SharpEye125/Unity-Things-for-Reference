using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    float direction;
    Transform player;
    public Vector2 shootDir;
    [Header("General Variables")]
    public GameObject prefab;
    public Joystick joystick;
    [Header("Shoot Variables")]
    public float shootDelay = 1.0f;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 1.0f;
    //public int extraBullets = 0;
    public float timer = 0f;
    Animator anim;
    //UNITY FUNCTIONS

    void Start()
    {
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Shoot();
        if (joystick.Direction != new Vector2(0, 0))
        {
            
            direction = joystick.Direction.x;
            transform.right = joystick.Direction;
            if (direction < 0)
            {
                GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (direction > 0)
            {
                GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }
    //PLAYER SHOOT FUNCTIONS
    public void Shoot()
    {
        if (joystick.Direction != new Vector2(0, 0) && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            shootDir = new Vector2(joystick.Direction.x, joystick.Direction.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            //anim.SetTrigger("shoot");
            Destroy(bullet, bulletLifetime);

        }
    }

    void Temporary()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;
        transform.right = joystick.Direction;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    }
}
