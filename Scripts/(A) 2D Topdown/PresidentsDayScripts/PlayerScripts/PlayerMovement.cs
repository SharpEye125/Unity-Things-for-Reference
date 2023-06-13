using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Joystick joystick;
    public Vector2 moveDir;
    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        moveDir = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
            SceneManager.LoadScene("Cutscene");
    }
}
