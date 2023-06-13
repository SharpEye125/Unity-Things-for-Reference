using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryTeleport : MonoBehaviour
{
    public GameObject Teleport;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Teleport")
        {
            
            timer += Time.deltaTime;
            if (timer > 20)
            {
                
            }
        }
    }
}
