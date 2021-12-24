using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Heart_Queen : MonoBehaviour
{

    public GameObject[] card_Soldier;
    public RushCard[] RushCard;
    public Vector3[] RushCardPos;
    public GameObject Hedgehog;
    public GateBall GB;
 

    private void OnEnable()
    {
        Invoke("DoPattern", 10f);
    }

    private void OnDisable()
    {
        CancelInvoke("DoPattern");
    }
    void DoPattern()
    {
        int rand = Random.Range(1, 101);

        if (rand >= 1 && rand <= 25)
            Execute();

        else if (rand >= 26 && rand <= 60)
            StartCoroutine("CardRush");

        else if (rand >= 61 && rand <= 90)
            HedgehogRush();

        else
            StartGateBall();

    }

    void Execute()
    {
        card_Soldier[0].GetComponent<Card_Soldier>().Execute();
        card_Soldier[1].GetComponent<Card_Soldier>().Execute();

        Invoke("DoPattern", 10f);
    }

    IEnumerator CardRush()
    {
        int st = -1;
        int nd = -2;
        st = Random.Range(0, 24);
        RushCard[st].Rush();
        nd = Random.Range(0, 24);
        while(st == nd)
            {
            nd = Random.Range(0, 24);

        }
        RushCard[nd].Rush();
        yield return new WaitForSeconds(5f);
        RushCard[st].transform.position = RushCardPos[st];
        RushCard[nd].transform.position = RushCardPos[nd];
        Invoke("DoPattern", 5f);
    }

    void HedgehogRush()
    {
        StartCoroutine("HedgehogRushing");
    }

    IEnumerator HedgehogRushing()
    {
        Hedgehog.SetActive(true);
        Hedgehog.transform.DOMove(new Vector3(0, 1.35f, 0),1f);
      //  Hedgehog.transform.position = new Vector3(0, 1.35f, 0);
        yield return new WaitForSeconds(12f);
        Hedgehog.SetActive(false);
        Hedgehog.transform.position = new Vector3(0, 6f, 0);
        Invoke("DoPattern", 3f);
    }

    void StartGateBall()
    {
        GB.FadeIN();
    }
}
