using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Queen : MonoBehaviour
{

    public GameObject[] card_Soldier;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Execute", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Execute()
    {
        card_Soldier[0].GetComponent<Card_Soldier>().Execute();
        card_Soldier[1].GetComponent<Card_Soldier>().Execute();

        Invoke("Execute", 10f);
    }
}
