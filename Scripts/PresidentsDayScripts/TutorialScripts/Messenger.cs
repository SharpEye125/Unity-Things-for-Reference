using System.Collections;
using UnityEngine;
public class Messenger : MonoBehaviour
{
    public Canvas messageCanvas;
    public Canvas HUD;
    public Vector2 nextToDesk;
    public Vector2 leavePos;
    public bool moveTowards = true;
    public bool once;
    void Start() 
    { 
        messageCanvas.enabled = false; 
        HUD.enabled = false; 
    }
    void Update()
    {
        if(moveTowards == true && transform.position != new Vector3(nextToDesk.x, nextToDesk.y, transform.position.z) && once == false)
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(nextToDesk.x, nextToDesk.y), .1f);
        else if (moveTowards == false)
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(leavePos.x, leavePos.y), .01f);
        if (transform.position == new Vector3(nextToDesk.x, nextToDesk.y, transform.position.z) && once == false)
            StartCoroutine(GoAway());
    }
    IEnumerator GoAway()
    {
        once = true;
        yield return new WaitForSeconds(3f);
        moveTowards = false;
        messageCanvas.enabled = true;
    }
}
