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
        MH = GameObject.FindGameObjectWithTag("MadHatter").GetComponent<MadHatter>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Body" && MH.isAble == true)
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
