using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_UI : MonoBehaviour
{
   public int min;
   public float sec;

    public Text txt;
    GameManager gm;
    private void Awake()
    {
        gm = GameManager.GM_Instance;
    }
    private void Start()
    {
        if (gm.stagenum == 1 || gm.stagenum == 2)
        {
            min = 1;
            sec = 0;
        }
        else if (gm.stagenum == 3)
        {
            min = 2;
            sec = 0;
        }
        else if (gm.stagenum == 4 || gm.stagenum == 5)
        {
            min = 2;
            sec = 0;
        }
        else if (gm.stagenum == 6)
        {
            min = 4;
            sec = 0;
        }
        else if (gm.stagenum == 7 || gm.stagenum == 8)
        {
            min = 2;
            sec = 0;
        }
        else
        {
            min = 5;
            sec = 0;
        }
    }

    void Update()
    {
        time();
    }

    void time()
    {
        sec -= Time.deltaTime;
        if (sec <= 0)
        {
            sec = 60;
            min -= 1;
        }
        txt.text = string.Format("{0}:{1:D2}", min, (int)sec);
        
    }
   
}
