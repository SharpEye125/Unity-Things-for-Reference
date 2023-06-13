using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SampleSimpleInteractableFunc : MonoBehaviour
{
    public GameObject prefab;
    public GameObject defaultPrefab;
    public Transform spawnPoint;
    //public Collider itemSocket;
    //public bool useXRSockets = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if((other.gameObject).tag == "Duplicatable" && (other.gameObject).GetComponent<XRSocketInteractor>() == false || (other.gameObject).tag == "Duplicatable" && (other.gameObject).GetComponent<XRSocketInteractor>() == false)
        {
            prefab = (other.gameObject);
        }
        else
        {
            prefab = defaultPrefab;
        }
    }

    public void SpawnPrefab()
    {
        GameObject duplicated = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        duplicated.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        duplicated.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Destroy(duplicated, 30);
    }
}
