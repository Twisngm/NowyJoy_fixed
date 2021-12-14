using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GateBall : MonoBehaviour
{
    public float limitTime = 10;
    public bool isGate = false;
    public bool isGoal = false;
    public int goalCnt = 0;

    public GameObject[] backGrounds;
    public GameObject[] Units;
    public Image fade;
    public GameObject Wall;
    public GameObject ball;
    public GameObject[] gates;
    public GameObject Goal;
    public GameObject timer;
    public GameObject Player;

    public Heart_Queen HQ;
    // Start is called before the first frame update
    void Start()
    {
        HQ = GameObject.Find("Heart_Queen").GetComponent<Heart_Queen>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        FadeOUT();
    }

    public void FadeIN()
    {
        StartCoroutine("FadeIn");
    }

    public void FadeOUT()
    {
        if(isGoal)
        {
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeIn()
    {
        fade.DOFade(1, 1f);
        
        yield return new WaitForSeconds(1f);
        goalCnt = 0;
        backGrounds[0].SetActive(false);

        Wall.SetActive(true);

        for (int i = 0; i < Units.Length; i++)
        {
            Units[i].SetActive(false);
        }

        timer.SetActive(true);

        ball.SetActive(true);
        ball.transform.position = new Vector3(0, -2.55f, 0);

        Goal.SetActive(true);

        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(true);
        }
        Player.transform.position = new Vector3(0, -3.5f, 0);

        fade.DOFade(0, 1f);
        isGate = true;
    }

    IEnumerator FadeOut()
    {
        isGoal = false;
        fade.DOFade(1, 1f);

        yield return new WaitForSeconds(1f);
        backGrounds[0].SetActive(true);

        Wall.SetActive(false);

        for (int i = 0; i < Units.Length; i++)
        {
            Units[i].SetActive(true);
        }

        timer.SetActive(false);

        ball.SetActive(false);

        Goal.SetActive(false);

        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(false);
        }
        Player.transform.position = new Vector3(0, -3.5f, 0);

        isGate = false;
        limitTime = 10;
        fade.DOFade(0, 1f);
        
    }

    void CountDown()
    {
        if(isGate && limitTime >= 0)
        {
            limitTime -= Time.deltaTime;
        }
    }
}
