using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private ScoresCollector scoresCollector;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
