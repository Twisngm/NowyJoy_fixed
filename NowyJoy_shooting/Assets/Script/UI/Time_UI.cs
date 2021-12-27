using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_UI : MonoBehaviour
{
   public int min;
   public float sec;
    public float GaugeValue;
    public Image Gauge;

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
        GaugeValue = min * 60;
    }

    void Update()
    {
        time();

        if (gm.stagenum == 1 || gm.stagenum == 2)
        {
            Gauge.fillAmount =  GaugeValue / 60;
        }
        else if (gm.stagenum == 3)
        {
            Gauge.fillAmount = GaugeValue / 120;
        }
        else if (gm.stagenum == 4 || gm.stagenum == 5)
        {
            Gauge.fillAmount = GaugeValue / 120;
        }
        else if (gm.stagenum == 6)
        {
            Gauge.fillAmount = GaugeValue / 240;
        }
        else if (gm.stagenum == 7 || gm.stagenum == 8)
        {
            Gauge.fillAmount = GaugeValue / 120 ;
        }
    }

    void time()
    {   
            sec -= Time.deltaTime;
          GaugeValue = sec;
            if (sec <= 0)
            {
                sec = 60;
                min -= 1;

            }
        if (min >= 0 && sec >= 0)
        {
            txt.text = string.Format("{0}:{1:D2}", min, (int)sec);
        }


    }
   
}
