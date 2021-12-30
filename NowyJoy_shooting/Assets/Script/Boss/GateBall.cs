using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GateBall : MonoBehaviour
{
    public float limitTime = 15;
    public bool isGate = false;

    public int goalCnt = 0;

    public GameObject[] backGrounds;
    public GameObject[] Units;
    public Image fade;
    public GameObject Wall;
    public GameObject ball;
    public GameObject[] gates;
    public GameObject[] Triggers;
    public Vector3[] GateVec;

    public GameObject timer;
    public GameObject Player;
    public Animator anim;
    public PolygonCollider2D PlayerCol;
    public GameObject PlayerEffect;

    public Heart_Queen HQ;

    public GameObject PM;
    GameObject[] Gate_Units;
    // Start is called before the first frame update
    void Start()
    {
        HQ = GameObject.Find("Heart_Queen").GetComponent<Heart_Queen>();
        StartCoroutine("GoalFail");
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        if(goalCnt == 3)
            FadeOUT();
       
    }

    public void FadeIN()
    {
        StartCoroutine("FadeIn");
    }

    public void FadeOUT()
    {
       
      StartCoroutine("FadeOut");
        
    }

    IEnumerator FadeIn()
    {
        fade.DOFade(1, 1f);
        PM.SetActive(false);
        yield return new WaitForSeconds(1f);
        goalCnt = 0;
        backGrounds[0].SetActive(false);

        PlayerEffect.SetActive(false);

        Wall.SetActive(true);

        for (int i = 0; i < Units.Length; i++)
        {
            Units[i].SetActive(false);
        }
        PlayerCol.isTrigger = false;
        timer.SetActive(true);

        ball.SetActive(true);
        ball.transform.position = new Vector3(0, -2.55f, 0);

        

        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(true);
            Triggers[i].SetActive(true);
        }

        Player.transform.position = new Vector3(0, -3.5f, 0);

        fade.DOFade(0, 1f);

        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].transform.DOMove(GateVec[i], 0.5f).SetEase(Ease.Linear);    
        }

        isGate = true;
    }

    IEnumerator FadeOut()
    {
       
        fade.DOFade(1, 1f);
        goalCnt = 0;
        yield return new WaitForSeconds(1f);
        backGrounds[0].SetActive(true);

        Wall.SetActive(false);

        for (int i = 0; i < Units.Length; i++)
        {
            Units[i].SetActive(true);
        }

        PlayerCol.isTrigger = true;
        timer.SetActive(false);

        ball.SetActive(false);

 

        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].transform.position = new Vector3(gates[i].transform.position.x, 9, gates[i].transform.position.z); 
            gates[i].SetActive(false);
        }
        Player.transform.position = new Vector3(0, -3.5f, 0);
        PlayerEffect.SetActive(true);
        isGate = false;
        PM.SetActive(true);
        limitTime = 15;
        fade.DOFade(0, 1f);
        
    }

    void CountDown()
    {
        if(isGate && limitTime >= 0)
        {
            limitTime -= Time.deltaTime;
        }
    }

    IEnumerator GoalFail()
    {
        if(limitTime <= 0 && goalCnt < 3)
        {
            anim.Play("SmokeFX4");
            yield return new WaitForSeconds(0.45f);

            if (GameManager.GM_Instance.Perfectmode == false)
            {
                if (goalCnt == 0)
                    GameManager.GM_Instance.HP -= 15;

                else if (goalCnt == 1)
                    GameManager.GM_Instance.HP -= 12;

                else if (goalCnt == 2)
                    GameManager.GM_Instance.HP -= 8;

                else
                    GameManager.GM_Instance.HP -= 4;
            }
            Debug.Log("adf");
            StartCoroutine("FadeOut");
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine("GoalFail");
        }
    }
}
