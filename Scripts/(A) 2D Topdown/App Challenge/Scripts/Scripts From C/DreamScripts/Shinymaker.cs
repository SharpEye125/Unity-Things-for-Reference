using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinymaker : MonoBehaviour
{
   public GameObject[] count;
    public GameObject projectile;
    public GameObject lazer;
    public Vector2 bouble;
    public float c;
    // Start is called before the first frame update
    void Start()
    {
        bouble = GameObject.FindGameObjectWithTag("Double").GetComponent<Double>().avpos;
    }

    // Update is called once per frame
    void Update()
    {
        bouble = GameObject.FindGameObjectWithTag("Double").GetComponent<Double>().avpos;
        count = GameObject.FindGameObjectsWithTag("Shiny");
        if (count.Length < 1)
        {
            c += Time.deltaTime;
            if(c>=4)
            {
                lazer = Instantiate(projectile, bouble, Quaternion.identity) as GameObject;
                c = 0;
            }
           
        }
          
    }
}
