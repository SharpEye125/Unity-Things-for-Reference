using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public GameObject aimer;
    public float apple;
    public float hey;
    public int ss;
    public static int sm;
    public AudioSource audioSource;
    public AudioClip bad;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Singleton.score = 100;
        ss = Singleton.stress;
        sm = Singleton.money;
        if (Singleton.streak == 0)
        {
            Singleton.streak = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<AudioSource>().volume = 1 - (Vector2.Distance(transform.position, aimer.transform.position)/2);
        hey += Time.deltaTime;
        if(hey>= 2/Singleton.streak)
        {
            hey = 0;
            GetComponent<Rigidbody2D>().drag =Random.Range(0,3);
            GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.5f, 2f);

        }
        apple += Time.deltaTime;
        if (apple >= 2f)
        {
            GetComponent<AudioSource>().volume = 1- Vector2.Distance(transform.position, aimer.transform.position);
            audioSource.PlayOneShot(bad);
            apple = 0;
           
           if (Vector2.Distance(transform.position, aimer.transform.position) > 1f && Singleton.stress<100)
            {
                Singleton.stress += 1 * Singleton.streak;
                if (Singleton.energy > 0)
                {
                    Singleton.energy -= 1;
                }
            }
            else if(Singleton.stress>0 && Singleton.stress >ss - (2*Singleton.streak))
            {
                Singleton.stress -= 1;
            }
        }
        GameObject aim = GameObject.FindGameObjectWithTag("bobaim");
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(aim.transform.position - transform.position);
            GetComponent<Animator>().SetBool("Up", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Up", false);
        }
        Debug.Log(Singleton.score);
    }
}