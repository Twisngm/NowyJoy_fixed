using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Trigger_Bird : MonoBehaviour
{

    public Time_UI time;
    public GameObject[] Boss;
    public GameObject bird;
    public GameObject owl;
    public PatternManager PM;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        BossTrigger();
    }

    void BossTrigger()
    {
        if (time.min <= 0)
        {        
          for(int i = 0; i < Boss.Length; i++)
            {
                Boss[i].SetActive(true);
                PM.isBoss = true;
            }
        }
    }
}
