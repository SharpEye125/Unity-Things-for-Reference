using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{
    //Using floats for min and max for possible use for different orientations of a lever
    public float maxRotationAct = -30f;
    public float minRotationAct = 30f;

    //Only have 1 of these true at one time
    public bool xRotation = true;
    public bool yRotation = false;
    public bool zRotation = false;

    public Transform rotationTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //X Rotation
        if (xRotation && !yRotation && !zRotation)
        {
            if (transform.rotation.x <= maxRotationAct)
            {
                LeverPastMax();
            }
            else if (transform.rotation.x <= minRotationAct)
            {
                LeverPastMin();
            }
            else
            {
                LeverInbetween();
            }
        }
        //Y Rotation
        else if (!xRotation && yRotation && !zRotation)
        {
            if (transform.rotation.y <= maxRotationAct)
            {
                LeverPastMax();
            }
            else if (transform.rotation.y <= minRotationAct)
            {
                LeverPastMin();
            }
            else
            {
                LeverInbetween();
            }
        }
        //Z Rotation
        else if (!xRotation && !yRotation && zRotation)
        {
            if (transform.rotation.z <= maxRotationAct)
            {
                LeverPastMax();
            }
            else if (transform.rotation.z <= minRotationAct)
            {
                LeverPastMin();
            }
            else
            {
                LeverInbetween();
            }
        }
    }
    public void LeverPastMax()
    {

    }
    public void LeverPastMin()
    {

    }
    public void LeverInbetween()
    {

    }
}
