using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textUIpos : MonoBehaviour
{
    public GameObject[] texts;
    public GameObject[] stages;

    private void Update()
    {
        if (texts.Length != 0 && stages.Length != 0)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].transform.position = Camera.main.WorldToScreenPoint(stages[i].transform.position + new Vector3(0, -0.7f, 0));
            }
        }
    }
}
