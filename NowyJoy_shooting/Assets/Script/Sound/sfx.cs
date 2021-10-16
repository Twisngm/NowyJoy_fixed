using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfx : MonoBehaviour
{
    [SerializeField]
    private string click;
    [SerializeField]
    private string getcoin;



    public void coinSound()
    {
            SoundManager.Instance.PlaySE(getcoin);
    }

    public void clickSound()
    {
            SoundManager.Instance.PlaySE(click);
    }
}
