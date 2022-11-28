using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{


    [SerializeField] private ScoresCollector scoresCollector;



    //protected override void Awake()
    //{
    //    base.Awake();

    //    Load();
    //}



    //#if UNITY_EDITOR
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
    //#endif
    //protected override void OnBallCollisionSegment(SegmentType type)
    //{
    //    if (type == SegmentType.Finish)
    //    {
    //        currentLevel++;

    //        if (scoresCollector.Scores > scoresCollector.RecordScores)
    //        {
    //            scoresCollector.RecordScores = scoresCollector.Scores;
    //        }
    //        Save();
    //    }
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetInt("LevelProgress:CurrentLevel", currentLevel);
    //    PlayerPrefs.SetInt("LevelProgress:scoresCollector", scoresCollector.RecordScores);
    //}

    //private void Load()
    //{
    //    currentLevel = PlayerPrefs.GetInt("LevelProgress:CurrentLevel", 1);
    //    scoresCollector.RecordScores = PlayerPrefs.GetInt("LevelProgress:scoresCollector");

    //}
    //#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //#endif
}
