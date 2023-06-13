using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerObjectOoB : MonoBehaviour
{
    public bool useMinimumY = false;
    public float minY;
    Vector3 startPos;
    Vector3 startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (useMinimumY)
        {
            if(transform.position.y < minY)
            {
                BackToStartPos();
            }
            
        }

    }
    public void BackToStartPos()
    {
        transform.position = startPos;
        transform.eulerAngles = startRotation;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "OutOfBounds")
        {
            BackToStartPos();
        }
    }
}
