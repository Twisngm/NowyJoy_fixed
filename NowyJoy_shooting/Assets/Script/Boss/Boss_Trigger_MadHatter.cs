using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Trigger_MadHatter : MonoBehaviour
{
    public Time_UI time;
    public GameObject Boss;
    public PatternManager PM;
    // Start is called before the first frame update
    void Update()
    {
        BossTrigger();
    }

    void BossTrigger()
    {
        if (time.min <= 4)
        {
          
                Boss.SetActive(true);
                PM.isBoss = true;
            
        }
    }
}
