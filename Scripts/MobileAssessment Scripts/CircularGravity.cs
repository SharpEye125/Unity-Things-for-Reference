using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{
    public float massOfPlanet;
    public Transform centerOfPlanet;

    float massOfPlayer;
    float distance;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        massOfPlayer = rb.mass;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
