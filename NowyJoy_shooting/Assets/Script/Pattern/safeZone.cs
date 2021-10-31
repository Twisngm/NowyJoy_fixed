using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeZone : MonoBehaviour
{
    GameObject safezone;
    float checktime = 0f;
    float randomX = Random.Range(0f, 1440f);
    float randomY = Random.Range(0f, 2960f);
    Vector2 pos;

    private void Start()
    {
        StartCoroutine("showsafeZone");
    }

    IEnumerator showsafeZone()
    {
        while (checktime <= 10f)
        {
            safezone.SetActive(true);
            safezone.transform.position = new Vector2(randomX, randomY);
            checktime += 1f;
            yield return null;
        }
        if (checktime > 10f)
        {
            safezone.SetActive(false);
            checktime = 0f;
        }
    }
}
