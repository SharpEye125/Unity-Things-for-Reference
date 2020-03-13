using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScene : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public Canvas third;
    public float endTime;
    public float timer;
    void Start() 
    { 
        second.gameObject.SetActive(false); 
        third.enabled = false; 
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 12)
            first.gameObject.SetActive(false);
        if (timer > 12.50f)
            second.SetActive(true);
        if (timer > 16)
            third.enabled = true;
    }
    public void MainMenu() { SceneManager.LoadScene("MainMenu"); }
}
