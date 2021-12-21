using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GateBallTimer : MonoBehaviour
{
    
    public Text txt;
    public GateBall GB;
  
    // Update is called once per frame
    void Update()
    {
        time();
      
    }
    void time()
    {
       
        txt.text = string.Format("{0}", GB.limitTime);

    }
}
