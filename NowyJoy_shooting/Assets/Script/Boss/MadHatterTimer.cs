using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadHatterTimer : MonoBehaviour
{
    public MadHatter MH;
    public Text txt;
    void Update()
    {
        time();

    }
    void time()
    {

        txt.text = string.Format("{0}", MH.FollowTime);

    }
}
