using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Queen : MonoBehaviour
{

    public GameObject[] card_Soldier;
    public GameObject RushCard;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DoPattern", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DoPattern()
    {
        int rand = Random.Range(1, 101);

        if (rand >= 1 && rand <= 50)
            Execute();

        else if (rand >= 51 && rand <= 75)
            CardRush();

        else if (rand >= 76 && rand <= 100)
            CardRush();

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
}
