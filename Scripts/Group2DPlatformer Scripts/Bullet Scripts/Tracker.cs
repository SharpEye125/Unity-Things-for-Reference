using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{

    public float speed = 5f;
    public int damage = 1;
    //public float chaseDistance = 10f;
    //public Transform nearestEnemy;
    public Rigidbody2D rb;

    public GameObject target;
    public bool instant = false;
    float dist = 10000;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (target == null)
        {
            FindTarget();
        }
        else
        {
            if (instant)
            {
                transform.position = target.transform.position;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                transform.right = Vector2.Lerp(transform.right, target.transform.position - transform.position, 0.2f * timer);//0.053f);
                float speed = GetComponent<Rigidbody2D>().velocity.magnitude;
                GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            }
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
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

