using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_UI : MonoBehaviour
{
   public int min;
   float sec;

    public Text txt;

    
    void Update()
    {
        time();
    }

    void time()
    {
        sec += Time.deltaTime;
        if (sec >= 60)
        {
            sec = 0;
            min += 1;
        }
        txt.text = string.Format("{0}:{1:D2}", min, (int)sec);
        
    }
   
}
