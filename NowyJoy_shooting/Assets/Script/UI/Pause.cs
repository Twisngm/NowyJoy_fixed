using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPause = false;

    void Update()
    {
        if (isPause)
            Time.timeScale = 0;
        else if(!isPause)
            Time.timeScale = 1;
    }

   public void OnPause()
    {
        isPause = true;
    }

    public void OffPause()
    {
        isPause = false;
    }
}
