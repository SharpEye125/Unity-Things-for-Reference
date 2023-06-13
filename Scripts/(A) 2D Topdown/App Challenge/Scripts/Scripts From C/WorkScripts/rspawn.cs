using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rspawn : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public GameObject lazer;
    private float timer;
    public float stime;
    public float ss;
    // Start is called before the first frame update
    void Start()
    {
        RR.rs = 0;
        ss = stime;
        ss = ss * Random.Range(0.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ss)
        {
            timer = 0;
            ss = stime;
            ss = ss * Random.Range(0.5f, 2);
            lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        }
    }
}
