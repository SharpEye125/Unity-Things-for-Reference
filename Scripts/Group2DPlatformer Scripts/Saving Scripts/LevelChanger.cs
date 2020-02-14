using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        {
            //FadeToNextLevel();
        }
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
            SceneManager.LoadScene(levelToLoad);
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        return;
    }
}
