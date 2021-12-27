using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameManager GM;
    public GameObject button1;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.GM_Instance;
        if (GM.Perfectmode)
        {
            button1.SetActive(true);
        }
        else
        {
            button1.SetActive(false);
        }
        if (GM.isUnlock)
        {
            button2.SetActive(true);
        }
        else
        {
            button2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerfectMode()
    {
        GameManager.GM_Instance.PerfectMode();
    }
    public void UnlockMode()
    {
        GameManager.GM_Instance.UnlockMode();
    }
}
