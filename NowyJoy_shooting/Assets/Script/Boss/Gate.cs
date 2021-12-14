using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject[] flame;
    public GateBall GB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
            for (int i = 0; i < 3; i++)
                flame[i].GetComponent<SpriteRenderer>().color = Color.white;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            for (int i = 0; i < 3; i++)
                flame[i].GetComponent<SpriteRenderer>().color = Color.green;

            GB.goalCnt++;
        }
    }
}
