using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeUI : MonoBehaviour
{
    public Vector3 sizegoal;
    public bool sizegot;
    public float sizem;
    public float gtime;
    public int ran;
    public float x;
    public Vector3 scaleChange;
    public GameObject me;
    public bool big;
    public float timer;
    public float upfreq;
    public float sC;
    public float sss;
    public AudioSource audiosource;
    public AudioClip gsfx;
    public AudioClip bsfx;
    public AudioClip sfx;
    public bool sfxp;
    public GameObject vfx;
    public float dur;
    [SerializeField] [Range(0, 1)] public float sfxv = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        big = true;
        sss = sC * Random.Range(1f,2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        scaleChange = new Vector3(sss, sss, sss);

        timer += Time.deltaTime;
        if (timer >= upfreq)
        {
            timer = 0;
            if (sizegot == false)
            {
                sizegot = true;
                if (big == true)
                {

                    ran = Random.Range(3, 5);

                }
                else
                {
                    ran = 0;
                }

                sizegoal = new Vector3(ran, ran, ran);
            }
            if (sizegot == true && me.transform.localScale != new Vector3(0, 0, 0))
            {
                if (x < ran + sss && x > ran - sss)
                {
                    sizegot = false;
                    sss = sC * Random.Range(1f, 2f);
                    if (big == true)
                    {
                        big = false;
                    }
                    else
                    {
                        big = true;
                        audiosource.PlayOneShot(bsfx, sfxv);
                        sfxp = false;
                        Singleton.energy -= 1;
                        Singleton.stress += 1;
                    }
                }
                x = me.transform.localScale.x;
                if (x < ran)
                {
                    me.transform.localScale += scaleChange;
                }
                if (x > ran)
                {
                    me.transform.localScale -= scaleChange;
                    if (x<0.5f)
                    {
                        if (sfxp == false)
                        {
                            audiosource.PlayOneShot(sfx, sfxv);
                            sfxp = true;
                        }
                       
                    }
                }

            }
            if (Input.GetKey(KeyCode.Space))

            {
                if (big == false)
                {
                    big = true;
                    sizegot = false;
                    if (x < 0.5f)
                    {
                        audiosource.PlayOneShot(gsfx, sfxv);
                        sfxp = false;
                        Singleton.energy += 2;
                        GameObject explosion = Instantiate(vfx, transform.position, transform.rotation);
                        Destroy(explosion, dur);
                    }
                    else if (x>0.5f)
                    {
                        audiosource.PlayOneShot(bsfx, sfxv);
                        sfxp = false;
                        Singleton.energy -= 1;
                    }
                }
            }
        }
    }

}
