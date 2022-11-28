using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject defeatPanel;

    [SerializeField] StoneSpawner stoneSpawner;


    private void Start()
    {
        
    }

    public void startLvl(bool start)
    {
        stoneSpawner.StartLvL = true;
        StartPanel.SetActive(false);
    }
}
