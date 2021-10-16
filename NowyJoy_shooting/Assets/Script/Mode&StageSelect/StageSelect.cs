using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public GameObject stage1_1;
    //float checkTime = 0f;

    //[SerializeField] [Range(1f, 5f)] float scaleSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            if (collision.name == "1-1")
            {
                Debug.Log("1-1과 닿았습니다.");
            }
        }
    }
}
