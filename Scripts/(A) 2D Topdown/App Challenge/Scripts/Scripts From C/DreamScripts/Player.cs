using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip yellSound;
    public AudioClip hurtsound;
    [SerializeField] [Range(0, 1)] public float yellVolume = 0.75f;
    public float wel;
   public int ac = 10;
    public int sp;
    public static bool hurt;
    public static bool collect;
    public AudioSource audiosource;
    public float hc;
    void Start()
    {

    }
    void Update()
    {
        wel += Time.deltaTime;

        if (wel >= 0.01f)
        {
            wel = 0;
            if (Input.GetKey(KeyCode.W))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, ac));
            }
            if (Input.GetKey(KeyCode.S))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, -ac));

            }
            if (Input.GetKey(KeyCode.D))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(ac, 0));

            }
            if (Input.GetKey(KeyCode.A))

            {
                GetComponent<Rigidbody>().AddForce(new Vector2(-ac, 0));

            }
            if (Input.GetKey(KeyCode.Space))

            {
                ac += 1; 

            }
            vel();
        }

        if (Player.collect == true)
        {
            Debug.Log("Collected");
            audiosource.PlayOneShot(yellSound, yellVolume);
            Singleton.stress -= 1;
           Player.collect = false;

        }
        else
        {
            Debug.Log("nOT COLLECTING");    
        }

        hc -= Time.deltaTime;
        if (hurt == true && hc < 0.01f)
        {
            hc = 2;
            audiosource.PlayOneShot(hurtsound, yellVolume);
            Singleton.energy -= 2;
            Singleton.stress += 2;
            Debug.Log("yes I go hurt");

            hurt = false;
        }
        else hurt = false;

       
    }
    public void vel()
    {
        Vector2 newVel = GetComponent<Rigidbody>().velocity;
        newVel.x = Mathf.Clamp(newVel.x, -sp, sp);
        GetComponent<Rigidbody>().velocity = newVel;
        Vector2 newfall = GetComponent<Rigidbody>().velocity;
        newfall.y = Mathf.Clamp(newfall.y, -sp, sp);
        GetComponent<Rigidbody>().velocity = newfall;
    }
   
}