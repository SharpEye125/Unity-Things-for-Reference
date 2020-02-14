using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletlifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float shootTriggerDistance = 10.0f;
    float timer = 0;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //player.position.x;
        //player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootDelay)
        {
            timer = 0;
            GameObject Bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //Instantiate(prefab, transform.position, Quaternion.identity);
            Vector2 shootDir = new Vector2(player.position.x - transform.position.x,
                player.position.y - transform.position.y);
            if (timer > shootDelay && shootDir.magnitude < shootTriggerDistance)
            {
                timer = 0;
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                shootDir.Normalize();
                Bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
                Destroy(Bullet, bulletlifetime);
            }
        }
    }
}
