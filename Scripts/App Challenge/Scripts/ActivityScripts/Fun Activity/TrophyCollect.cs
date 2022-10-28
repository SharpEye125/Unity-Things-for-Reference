using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollect : MonoBehaviour
{
    public string playerTag = "Player";
    public AudioClip trophyDie;
    
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Spawning at: " + transform.position);
        pos = new Vector2(transform.position.x, transform.position.y);
        if (pos.x < 2 && pos.x > -2 && pos.y < 2 && pos.y > -2)
        {
            Debug.Log("Too close to middle");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != playerTag)
        {
            //Debug.Log("Spawned on top of something - Enter");
            Camera.main.GetComponent<AudioSource>().PlayOneShot(trophyDie);
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
}
