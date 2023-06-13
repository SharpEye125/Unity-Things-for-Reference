using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Ehealth = 5;
    public GameObject Drop1;
    public GameObject Drop2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Ehealth--;
            if (Ehealth < 1)
            {
                Destroy(gameObject);
                Instantiate (Drop1, transform.position, Quaternion.identity);
            }
        }
    }
}
