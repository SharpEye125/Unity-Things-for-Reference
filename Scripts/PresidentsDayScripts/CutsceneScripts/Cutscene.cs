using UnityEngine;
using UnityEngine.SceneManagement;
public class Cutscene : MonoBehaviour
{
    public float time;
    public float timer;
    void Start() { timer = 0; }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
            SceneManager.LoadScene("Arena");
    }
}
