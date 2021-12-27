using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
