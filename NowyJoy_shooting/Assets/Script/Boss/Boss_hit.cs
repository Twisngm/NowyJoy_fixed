using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_hit : MonoBehaviour
{
    public Time_UI time;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_Bullet")
        {
            time.sec -= 0.5f;
            time.GaugeValue -= 0.5f;
        }
    }
}
