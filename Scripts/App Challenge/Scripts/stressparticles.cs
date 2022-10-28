using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stressparticles : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ps = GetComponent<ParticleSystem>();
        var pse = ps.emission;
        pse.rate = Singleton.stress / 5;
      
    }
}
