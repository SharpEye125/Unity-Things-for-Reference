using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RR : MonoBehaviour
{
    public static int rs;
    public GameObject rgoal;
    public AudioSource audioSource;
    public int ridentity;
    public AudioClip bad;
    public AudioClip doit;
    public AudioClip good;
    public bool check;
    public float tim;
    public GameObject vfx;
    public float dur;
    public bool getlow;
    public GameObject[] rrs;

    // Start is called before the first frame update
    void Start()
    {
        rgoal = GameObject.Find("RGoal");
    }
    private void Awake()
    {
        rs++;
        ridentity = rs;
    }
    // Update is called once per frame
    void Update()
    {

        // Debug.Log("R distance "+Vector2.Distance(transform.position, rgoal.transform.position));
        if (Vector2.Distance(transform.position, new Vector3(6.5f, 0, 0)) < 0.1f)
        {
            GetComponent<Rigidbody2D>().drag = 102;
            if (check == false)
            {
                AudioSource.PlayClipAtPoint(doit, Camera.main.transform.position);
                check = true;
            }
        }
        if (GetComponent<Rigidbody2D>().drag == 102)
        {
            tim += Time.deltaTime;
            if (tim >= 0.5f)
            {
                Destroy(gameObject);
                rrs = GameObject.FindGameObjectsWithTag("RR");
                for (int i = 0; i < rrs.Length; i++)
                {
                    rrs[i].gameObject.GetComponent<RR>().ridentity -= 1;
                }
                rs--;
                Singleton.stress += 1;
                AudioSource.PlayClipAtPoint(bad, Camera.main.transform.position);
            }

        }
    
        if (Singleton.money > Bobber.sm + 10 + (10 * Singleton.streak))
        {
            Singleton.money = Bobber.sm + 10 + (10 * Singleton.streak);
        }
        if (Singleton.money < Bobber.sm - 10 - (10 * Singleton.streak))
        {
            Singleton.money = Bobber.sm - 10 - (10 * Singleton.streak);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && ridentity == 1)
        {
            
            
                if (GetComponent<Rigidbody2D>().drag == 102)
                {
                    Singleton.money += 1 * Singleton.streak;
                    AudioSource.PlayClipAtPoint(good, Camera.main.transform.position);
                GameObject explosion = Instantiate(vfx, transform.position, transform.rotation);
                Destroy(explosion, dur);
            }
                else
                {
                    Singleton.money -= 3;
                    AudioSource.PlayClipAtPoint(bad, Camera.main.transform.position);
                }
                Destroy(gameObject);
                rs--;
            
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1) && ridentity != 1)
        {
            ridentity--;
        }
          
    }
}
