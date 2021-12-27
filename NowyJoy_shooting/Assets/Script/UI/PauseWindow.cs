using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    public GameObject PauseWin;

    bool SetOn = true;
    // Start is called before the first frame update
    void Start()
    {
        PauseWin = transform.Find("Pause").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SetPause();
           
    }

    void SetPause()
    {
        if (PauseWin.activeSelf == true && !SetOn)
        {
            Pause.Instance.OnPause();
            SetOn = true;
        }
        else if (PauseWin.activeSelf == false && SetOn)
        {
            Pause.Instance.OffPause();
            SetOn = false;
        }
    }

    
}
