using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject key;
    public Transform keyPositionSnap;
    Rigidbody keyRB;
    bool inLock = false;
    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        keyRB = key.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inLock == true)
        {
            if (key.transform.eulerAngles.x <= 0f && key.transform.eulerAngles.x >= -30f)
            {
                keyRB.constraints = RigidbodyConstraints.None;
                //keyRB.isKinematic = false;
                key.GetComponent<PerObjectOoB>().BackToStartPos();
                inLock = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key") && inLock != true)
        {
            inLock = true;
            key.transform.position = keyPositionSnap.position;
            keyRB.velocity = new Vector3(0, 0, 0);
            key.transform.eulerAngles = new Vector3(-90, 180, 0);
        }
        
    }
}
