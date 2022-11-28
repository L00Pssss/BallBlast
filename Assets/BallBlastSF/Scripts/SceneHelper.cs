using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    LevelState levelState;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        levelState = GetComponent<LevelState>();
    }
    public void RestartLevel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void LoadLevel(int buildIndex)
    { 
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
