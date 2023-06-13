using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGrid : MonoBehaviour
{
    Transform camera;
    Vector3 previousCamPos;
    public float parallaxScale;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        previousCamPos = camera.position;
    }

    // Update is called once per frame
    void Update()
    {
        float parallax = (previousCamPos.x - camera.position.x) * parallaxScale;
        Vector3 pos = transform.position;
        pos.x += parallax;
        transform.position = pos;
        previousCamPos = camera.position;
    }
}
