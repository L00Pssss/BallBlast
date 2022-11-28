using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private Text scoreText;
    private void Start()
    {
        scoreText.text = scoresCollector.Scores.ToString();
    }
}
