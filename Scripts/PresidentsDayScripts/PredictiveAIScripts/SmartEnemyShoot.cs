﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemyShoot : MonoBehaviour
{
    public Vector2 targetVelocity;
    public Vector2 shootDir;
    public bool attackPlayer = true;
    int damage = 1;
    GameObject target;
    Rigidbody2D enemyRB;
    public float bulletSpeed = 5.0f;
    public GameObject projectile;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float targetRange = 15.0f;
    float timer = 0;
    float direction;
    Animator anim;

    public float dist = 10000;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        if (attackPlayer == true)
        {
            target = GameObject.FindGameObjectWithTag("Player").gameObject;
            enemyRB = target.GetComponent<Rigidbody2D>();
        }
        else
        {
            FindTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (target == null)
        {
            FindTarget();
        }
        if (enemyRB != null && target != null)
        {

            targetVelocity.x = enemyRB.velocity.x;
            targetVelocity.y = enemyRB.velocity.y;
            shootDir = new Vector2(target.transform.position.x - transform.position.x + targetVelocity.x,
                target.transform.position.y - transform.position.y + targetVelocity.y);
        }
        if (timer > shootDelay && target != null)
        {
            
            EnemyFire();
        }
        direction = shootDir.x;
        transform.right = shootDir;
        if (direction < 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (direction > 0)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

    }

    void EnemyFire()
    {
        timer = 0;
        //Debug.Log(name + " firing at " + target.name);
        targetVelocity.x = enemyRB.velocity.x;
        targetVelocity.y = enemyRB.velocity.y;
        shootDir = new Vector2(target.transform.position.x - transform.position.x + targetVelocity.x,
            target.transform.position.y - transform.position.y + targetVelocity.y);

        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        shootDir.Normalize();
        bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
        //anim.SetTrigger("shoot");
        Destroy(bullet, bulletLifetime);
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dist)
            {
                target = enemies[i];
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
                enemyRB = target.GetComponent<Rigidbody2D>();
            }
            else if (Vector3.Distance(transform.position, enemies[i].transform.position) < 10000)
            {
                target = enemies[i];
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
                enemyRB = target.GetComponent<Rigidbody2D>();
            }
        }
    }
}

