using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsReset : MonoBehaviour
{
    public GameObject resetPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        //Collision.gameObject.transform.position = resetPoint.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        collision.gameObject.transform.position = resetPoint.transform.position;
    }
}
