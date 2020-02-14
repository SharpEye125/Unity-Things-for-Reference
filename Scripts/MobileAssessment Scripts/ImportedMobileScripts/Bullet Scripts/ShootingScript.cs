using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject bounce;
    public GameObject tracker;

    [Range(2, 3)]
    public int powerUps = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //GetAxisRaw if value /= 0 then multiply projectile value by velocity when spawned

    // Update is called once per frame
    void Update()
    {
        float movegDir = GetComponent<MobilePlatMove>().moveX;
        if (movegDir == 1)
        {
            firePoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movegDir == -1)
        {
            firePoint.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetButtonDown("Fire1")&& Time.timeScale != 0)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        switch (powerUps)
        {
            case 2:
                Instantiate(bounce, firePoint.position, firePoint.rotation);
                break;
            case 3:
                Instantiate(tracker, firePoint.position, firePoint.rotation);
                break;
            default:
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                break;
        }
        
    }
    //Use Input.GetAxisRaw
}
