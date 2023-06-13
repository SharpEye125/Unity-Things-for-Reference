using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTurret : MonoBehaviour
{
    public Vector2 shootDir;
    public bool attackPlayer = true;
    //int damage = 1;
    GameObject target;
    public float bulletSpeed = 5.0f;
    public GameObject projectile;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float targetRange = 15.0f;
    float timer = 0;
    float timer2 = 0;
    float direction;
    Animator anim;
    public AudioClip fireSFX;
    //public float rotateSpeed = 5f;
    public bool click;

    public float dist = 10000;

    // Start is called before the first frame update
    void Start()
    {
        
        if (attackPlayer == true)
        {
            target = GameObject.FindGameObjectWithTag("Player").gameObject;
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                anim = null;
                fireSFX = null;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer2 > 5)
        {
            timer2 = 0;
            if (click == true)
            {
                click = false;
            }
            else if (click == false)
            {
                click = true;
            }
        }
        if (target == null)
        {
            FindTarget();

        }
        shootDir = new Vector2(target.transform.position.x - transform.position.x,
            target.transform.position.y - transform.position.y);
        direction = shootDir.x;
        transform.up = shootDir;
        if (direction < 0)
        {
            //GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (direction > 0)
        {
            //GetComponent<SpriteRenderer>().flipY = false;
        }
        if(click == true)
        {
            if (timer > shootDelay/2)
            {
                EnemyFire();
                if (fireSFX != null)
                {
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(fireSFX);
                }
            }
        }
        if (click == false)
        {
            if (timer > shootDelay)
            {
                EnemyFire();
                if (fireSFX != null)
                {
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(fireSFX);
                }
            }
        }
       
    }

    void EnemyFire()
    {
        timer = 0;
        if (shootDir.magnitude < targetRange)
        {
            //Debug.Log(name + " firing at " + target.name);
            anim.SetTrigger("Fire");
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dist)
            {
                target = enemies[i];
                Vector3.Distance(transform.position, enemies[i].transform.position);
            }
        }
    }
}
