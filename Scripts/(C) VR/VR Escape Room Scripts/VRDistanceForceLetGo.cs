using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class VRDistanceForceLetGo : MonoBehaviour
{
    public float maxDistance = 1f;
    public XRDirectInteractor myHandInteractor;
    public XRRayInteractor myRayInteractor;
    GameObject grabbedObject;

    // Start is called before the first frame update
    void Start()
    {
        myHandInteractor = GetComponent<XRDirectInteractor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grabbedObject != null)
        {
            if (grabbedObject.layer == 7 && Vector3.Distance(grabbedObject.transform.position, transform.position) > maxDistance)
            {
                myHandInteractor.allowSelect = false;
                grabbedObject = null;
                //myRayInteractor.allowSelect = false;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            grabbedObject = other.gameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            myHandInteractor.allowSelect = true;
            //myRayInteractor.allowSelect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
