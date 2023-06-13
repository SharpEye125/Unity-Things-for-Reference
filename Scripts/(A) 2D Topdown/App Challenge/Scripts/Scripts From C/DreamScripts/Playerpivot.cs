using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpivot : MonoBehaviour
{
    public float rotationalDamp = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Shiny") != null)
        {
            GameObject Shiny = GameObject.FindGameObjectWithTag("Shiny");
            Vector3 pos = Shiny.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }
}
