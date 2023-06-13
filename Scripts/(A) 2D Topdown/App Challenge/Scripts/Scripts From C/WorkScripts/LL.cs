using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL : MonoBehaviour
{
    public static int ls;

    public GameObject lgoal;
    public AudioClip bad;
    public AudioClip doit;
    public AudioClip good;
    public bool check;
    public AudioSource audioSource;
    public float tim;
    public GameObject vfx;
    public float dur;
    public GameObject[] lls;


    public int lidentity;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        ls++;
        lidentity = ls;
     
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, lgoal.transform.position) < 2f)
        {
            if (check == false)
            {
                GetComponent<Rigidbody2D>().drag = 102;
                AudioSource.PlayClipAtPoint(doit, Camera.main.transform.position);
                check = true;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && lidentity == 1)
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
            ls--;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && lidentity != 1)

        {
            lidentity--;
        }
        if (GetComponent<Rigidbody2D>().drag == 102)
        {
            tim += Time.deltaTime;
            if (tim >= 0.5f)
            {
                Destroy(gameObject);
                ls--;
                lls = GameObject.FindGameObjectsWithTag("LL");
                for (int i = 0; i < lls.Length; i++)
                {
                    lls[i].gameObject.GetComponent<LL>().lidentity -= 1;
                }
                Singleton.stress += 1;
                AudioSource.PlayClipAtPoint(bad, Camera.main.transform.position);
            }

        }
    }
}