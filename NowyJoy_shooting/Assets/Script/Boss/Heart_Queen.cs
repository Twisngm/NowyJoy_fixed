using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Queen : MonoBehaviour
{

    public GameObject[] card_Soldier;
    public GameObject RushCard;
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
        int rand = Random.Range(95, 101);

        if (rand >= 1 && rand <= 50)
            Execute();

        else if (rand >= 51 && rand <= 70)
            CardRush();

        else if (rand >= 71 && rand <= 90)
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

    void CardRush()
    {
        RushCard.GetComponent<RushCard>().Rush();
        Invoke("DoPattern", 10f);
    }

    void HedgehogRush()
    {
        StartCoroutine("HedgehogRushing");
    }

    IEnumerator HedgehogRushing()
    {
        Hedgehog.SetActive(true);
        Hedgehog.transform.position = new Vector3(0, 1.35f, 0);
        yield return new WaitForSeconds(12f);
        Hedgehog.SetActive(false);
        Invoke("DoPattern", 3f);
    }

    void StartGateBall()
    {
        GB.FadeIN();
    }
}
