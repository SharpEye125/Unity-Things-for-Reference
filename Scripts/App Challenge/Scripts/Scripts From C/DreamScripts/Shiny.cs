using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiny : MonoBehaviour
{
    public Vector2 bouble;
    public int i;
    public bool kill;
    public bool active;
    public GameObject vfx;
    public float dur;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (active == true)
        {
            GameObject[] friends = GameObject.FindGameObjectsWithTag("Double");
            kill = true;
            for (i = 0; i < friends.Length; i++)
            {

                if (Vector3.Distance(friends[i].transform.position, transform.position) < 10)
                {
                    friends[i].GetComponent<Rigidbody>().drag = 0;
                    friends[i].GetComponent<Rigidbody>().mass = 0.1f;

                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().AddForce(friends[i].transform.position - transform.position);
                    friends[i].GetComponent<Rigidbody>().mass = 01f;
                    kill = false;
                }
            }
            if (kill == true)
            {
                Singleton.gemsgot += 1;
                Player.collect = true;
                Debug.Log("Collect");
                GameObject explosion = Instantiate(vfx, transform.position, transform.rotation);
                Destroy(explosion, dur);
                Destroy(gameObject);
            }
        }
        else
        {
            bouble = GameObject.FindGameObjectWithTag("Double").GetComponent<Double>().avpos;
            GetComponent<Rigidbody>().AddForce(bouble - new Vector2(transform.position.x, transform.position.y));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
    }
}
