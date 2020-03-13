using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAI : MonoBehaviour
{
    public bool movingRight = true;
    public float speed = 2;
    public float bossSpeed = 5;
    //public bool atCheckPoint;
    //public Transform[] checkpoints;
    WaveSpawner waveCheck;
    Rigidbody2D rb;
    int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waveCheck = GameObject.FindGameObjectWithTag("WaveScripted").GetComponent<WaveSpawner>();
        //gameObject.GetComponent<EnemyHealth>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waveCheck.nextWave;
        if (waveCheck.state == WaveSpawner.SpawnState.WAITING || waveCheck.state == WaveSpawner.SpawnState.SPAWNING)
        {
            rb.velocity = transform.right * speed;
            //EEE

        }
        if (currentWave == 9)
        {
            
            gameObject.tag = "Enemy";
            speed = bossSpeed;
        }
        else
        {
            GetComponent<EnemyHealth>().enemyHealth = GetComponent<EnemyHealth>().maxEnemyHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Train Flip")
        {
            Debug.Log("Flipping");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
