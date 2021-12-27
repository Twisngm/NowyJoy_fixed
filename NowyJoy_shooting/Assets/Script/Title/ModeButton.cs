using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetActive()
    {
        if(this.gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else if(this.gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
    }
}
