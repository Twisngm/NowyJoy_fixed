using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeZone : MonoBehaviour
{
    public GameObject safezone;
    float checktime = 0f;
    public float randomX;
    public float randomY;
    public float testX;
    public float testY;
    public float randomTime;
    float time = 0f;

    private void Start()
    {
         randomX = Random.Range(0f, Screen.width);
         randomY = Random.Range(0f, Screen.height);
         randomTime = Random.Range(0f, 3f);
        start_safezone();
    }

    public void start_safezone()
    {
        StartCoroutine("showsafeZone");
    }

    IEnumerator createCorutine()
    {
        while (randomTime > time)
        {
            time += Time.deltaTime;
            yield return null;
        }
        if (randomTime <time)
        {
            StartCoroutine("showsafeZone");
            time = 0f;
        }
    }

    IEnumerator showsafeZone()
    {
        while (checktime <= 3f)
        {
            safezone.SetActive(true);
            checktime += 1f;
            yield return new WaitForSeconds(1f);
        }
        if (checktime > 3f)
        {
            safezone.SetActive(false);
            checktime = 0f;
            yield break;
        }
    }
}
