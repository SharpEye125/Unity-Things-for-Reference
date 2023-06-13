using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    public Vector2 shootDir;
    [Header("General Variables")]               
    public GameObject prefab;
    public Joystick joystick;
    [Header("Shoot Variables")]                 
    public float shootDelay = 1.0f;            
    public float bulletSpeed = 10.0f;     
    public float bulletLifetime = 1.0f;         
    //public int extraBullets = 0;
    public float timer = 0f;
    //UNITY FUNCTIONS
    void Update()
    {
        timer += Time.deltaTime;
        Shoot();
    }
    //PLAYER SHOOT FUNCTIONS
    public void Shoot()
    {
        if ( joystick.Direction != new Vector2(0,0) && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            shootDir = new Vector2(joystick.Direction.x, joystick.Direction.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}
