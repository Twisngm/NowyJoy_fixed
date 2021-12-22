using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUnlock : MonoBehaviour
{
    public GameObject[] stages = new GameObject[9];
    public int unlockedStage;
    public Text showStageNumber;
    public GameObject showpanel;

    void Start()
    {
        PlayerPrefs.SetInt("UnlockStage",1);
        PlayerPrefs.Save();
        unlockedStage = PlayerPrefs.GetInt("UnlockStage");
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].SetActive(false);
        }
        showStage();
    }

    void Update()
    {
        if (unlockedStage != PlayerPrefs.GetInt("UnlockStage"))
        {
            unlockedStage = PlayerPrefs.GetInt("UnlockStage");
            showStage();
        }
    }

    public void showStage()
    {
        for (int i = 0; i < unlockedStage; i++)
        {
            stages[i].SetActive(true);
        }
    }

    public void showPanel()
    {
        
    }
}
