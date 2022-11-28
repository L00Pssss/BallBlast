using UnityEngine;

public class ScoresCollector : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;

    [SerializeField] private int scores;
    public int Scores
    {
        get { return scores; }

        set { scores = value; }
    }
}
