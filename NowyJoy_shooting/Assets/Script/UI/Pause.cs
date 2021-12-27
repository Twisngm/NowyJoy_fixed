using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPause = false;
    public GameObject PauseWindow;

    private static Pause instance = null;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PauseWindow = GameObject.Find("UI").transform.Find("Pause").gameObject;
    }

    public static Pause Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

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
