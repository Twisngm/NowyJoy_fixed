using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Trigger : MonoBehaviour
{

    public Time_UI time;
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
        if (time.min <= 2)
        {
            bird.gameObject.SetActive(true);
            owl.gameObject.SetActive(true);
        }
    }
}
