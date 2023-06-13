using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject lazer;
    [SerializeField] float lazerSpeedY = 5f;
    [SerializeField] float lazerSpeedX = 5f;
    public GameObject[] doubles;
    public int D;
    public int i;
    public bool happy;
    public float[] doubleList;
    public int e = 0;
    public float distance;
    public float happyDist;
    public float atimer;
    Vector2 frenpos;
    Vector2 mepos;
    Vector2 movedir;
    public int had;
    float ranwait = 0;
    public float btimer;
    public bool angry;
    public int ran;
    public int angries;
    public float dietimer = 0;
    public float incrincr;
    public int spawnmax;
    public Rigidbody rb;
    public float rotationalDamp = 0.5f;
    public GameObject aimer;
    public int spd;
    public Vector2 avpos;
    public bool swerve;
    public bool show;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ranwait = Random.Range(0, 5);

        if(show==false)
        {
            spawnmax = 10 + (Mathf.RoundToInt(Singleton.stress) / 3);
        }
       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 totpos = new Vector2(0, 0);
        avpos = new Vector2(0, 0);
        GameObject[] friends = GameObject.FindGameObjectsWithTag("Double");
        for (i = 0; i < friends.Length; i++)
        {
            Vector2 newDist = friends[i].transform.position;
            if (friends[i] != gameObject)
            {
                //find average position of all cells
                totpos = totpos + newDist;
                avpos = totpos / i;
                mepos = gameObject.transform.position;
            }
        }
        {
            if (show== false)
            {
             player = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
               player = GameObject.FindGameObjectWithTag("Show");

            }

           Vector2 atpos = player.transform.position - transform.position;
            Vector2 newVel = GetComponent<Rigidbody>().velocity;
            newVel.x = Mathf.Clamp(newVel.x, -spd, spd);
            GetComponent<Rigidbody>().velocity = newVel;
            Vector2 newfall = GetComponent<Rigidbody>().velocity;
            newfall.y = Mathf.Clamp(newfall.y, -spd, spd); 
            GetComponent<Rigidbody>().velocity = newfall;
            doubles = GameObject.FindGameObjectsWithTag("Double");
            doubleList = new float[doubles.Length];
            dietimer += Time.deltaTime;
            if (dietimer >= incrincr)
            {
                //Make the max cells increase
                spawnmax += 1;
                dietimer = 0;
            }
            if (doubles.Length < spawnmax)
            {
                //If less cells than the max make a cell
                lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                lazer.GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(1 * -lazerSpeedX, 1 * lazerSpeedX), Random.Range(1 * -lazerSpeedY, 1 * lazerSpeedY));
            }
            for (D = 0; D < doubles.Length; D++)
            {
                //find distance of other cells
                distance = Vector3.Distance(transform.position, doubles[D].transform.position);
                doubleList[D] = distance;
            }
            happy = false;
            had = 0;
            for (e = 0; e < doubleList.Length; e++)
            {
                //check if enough cells are within happyDist to make happy = true
                if (doubleList[e] < happyDist && doubleList[e] > 1)
                {
                    had++;
                    if (had >= doubleList.Length / 5)
                    {
                        happy = true;
                    }
                }
            }
            if (angry == false)
            {
                if (happy == false)
                {
                    spd = 5;
                }
                else
                {
                    spd = 3;
                }

                atimer += Time.deltaTime;

                if (atimer >= 0.001)
                {
                    atimer = 0f;
                    Debug.DrawRay(transform.position, (avpos - mepos), Color.red, 0.01f);
                }
               if (show == false)
                {
                    Vector3 pos = new Vector3(avpos.x, avpos.y, 0) - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(pos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
                }
               else if(show == true)
                {
                    Vector3 pos =(player.transform.position) - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(pos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
                }               
               
                
                GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
                if (swerve == false)
                {
                    GetComponent<Rigidbody>().velocity = (aimer.transform.position - transform.position);
                    swerve = true;
                }
                rb.drag = 0.1f;
            }
            {
                //make cells angry
                if (show == false)
                {
                    ranwait += Time.deltaTime;
                    if (ranwait > Random.Range(5, 20))
                    {
                        ranwait = 0;
                        ran = Random.Range(1, 100);

                        if (ran > 50 && angries <= doubleList.Length * 0.2f)
                        {
                            angry = true;
                            if (Vector2.Distance(player.transform.position, transform.position) >= 10)
                            {
                                swerve = false;
                            }
                            angries += 1;
                        }
                        else
                        {
                            angry = false;
                            angries -= 1;
                        }
                    }
                }
            }
            if (angry == true)
            {
                spd = 8;
                Vector3 pos = player.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
               
                btimer += Time.deltaTime;
                Debug.DrawRay(transform.position, (atpos - new Vector2(transform.position.x, transform.position.y)), Color.blue, 0.01f);
                if (btimer >= 0.01)
                    btimer = 0f;
                GetComponent<Rigidbody>().AddForce(aimer.transform.position - transform.position);
                if (swerve == false)
                {
                    GetComponent<Rigidbody>().velocity = (aimer.transform.position - transform.position);
                    swerve = true;
                }
                rb.drag = 0.5f;
            }
           
            Debug.DrawRay(transform.position, (aimer.transform.position - transform.position), Color.magenta, 0.01f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.hurt = true;
        }
    }

}

