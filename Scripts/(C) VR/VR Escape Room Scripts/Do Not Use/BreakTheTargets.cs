using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTheTargets : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject[] targets;
    private Vector3 randPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length == 0)
        {

        }
    }

}
