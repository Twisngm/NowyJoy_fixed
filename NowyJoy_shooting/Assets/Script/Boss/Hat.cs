using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{

    public MadHatter MH;
    public bool isRight;


    private void OnDisable()
    {
        MH.time = 0;
        if (MH.isAble)
        {
            if (isRight)
            {
                MH.RightStart();
            }
            else if (!isRight)
            {
                MH.WrongStart();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
     //   MH = GameObject.Find("RaidBoss_MadHatter").GetComponent<MadHatter>();
    }

    // Update is called once per frame

/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body" && MH.isAble == true)
        {
            gameObject.SetActive(false);
            MH.isAble = false;
            Invoke("SetAble", 1f);
        }
    }



    void SetAble()
    {
        MH.isAble = true;
    }
}
