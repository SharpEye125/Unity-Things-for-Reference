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
            Destroy(gameObject);
        }
    }
}
