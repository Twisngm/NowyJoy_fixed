using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MadHatter_TImer : MonoBehaviour
{
    public MadHatter MH;
    public Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time();
      
    }
    void time()
    {
       
        txt.text = string.Format("{0}", MH.FollowTime);

    }
}
