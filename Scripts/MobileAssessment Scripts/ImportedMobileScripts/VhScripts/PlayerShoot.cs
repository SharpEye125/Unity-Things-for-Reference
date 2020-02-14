using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletlifetime = 1.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            GameObject Bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Input.mousePosition;
            Debug.Log(mousePosition);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log(mousePosition);
            Vector2 shootDir = new Vector2(mousePosition.x - transform.position.x, 
                mousePosition.y - transform.position.y);
            shootDir.Normalize();
            Bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(Bullet, bulletlifetime);
        } 
    }
}
