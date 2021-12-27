using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TittleStart : MonoBehaviour
{
    public RectTransform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoUP()
    {
        player.DOAnchorPos(new Vector2(0,10), 1f);
    }
}
