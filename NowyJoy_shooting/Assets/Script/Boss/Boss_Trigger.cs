using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Trigger : MonoBehaviour
{

    public Time_UI time;
    public GameObject[] Boss;
    public GameObject bird;
    public GameObject owl;
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
        if (time.min <= 3)
        {
            for(int i = 0; i< Boss.Length; i++)
            {
                Boss[i].gameObject.SetActive(true);
            }
           
        }
    }
}
