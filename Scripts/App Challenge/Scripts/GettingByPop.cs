using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingByPop : MonoBehaviour
{
    public float timer;
    public GameObject vfx;
    public float dur;
    public bool played;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4.1f && played == false)
        {
            GameObject explosion = Instantiate(vfx, transform.position, transform.rotation);
            Destroy(explosion, dur);
            played = true;
        }
    }
}
