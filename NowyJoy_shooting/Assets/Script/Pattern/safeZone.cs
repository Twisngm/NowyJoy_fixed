using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safeZone : MonoBehaviour
{
    public GameObject safezone;
    Image safezone_img;
    float checktime = 0f;
    public float randomX;
    public float randomY;
    public float testX;
    public float testY;
    public float randomTime;
    float time = 0f;
    float testTIME = 0f;
    float testerCount = 0f;

    private void Start()
    {
         randomX = Random.Range(0f, Screen.width);
         randomY = Random.Range(0f, Screen.height);
         randomTime = Random.Range(0f, 3f);
        //start_safezone();
        safezone_img = safezone.GetComponent<Image>();
    }

    void testf()
    {

    }

    IEnumerator tester()
    {
        time = 0f;
        while (3f > time)
        {
            time += Time.deltaTime;
            yield return null;
        }
        if (time > 3f)
        {
            safeZonAlpha(0);
            time = 0f;
        }
    }

    public void start_safezone()
    {
        testerCount += 1f;
        safeZonAlpha(0);
        StartCoroutine("showsafeZone");
    }

    void safeZonAlpha(int alphaCount)
    {
        Color safezone_color = safezone_img.color;
        if (alphaCount == 1)
        {
            safezone_color.a = 1;
            safezone_img.color = safezone_color;
        }
        else
        {
            safezone_color.a = 0;
            safezone_img.color = safezone_color;
        }
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
            safeZonAlpha(1);
            checktime += 0.1f;
            safezone.transform.position = new Vector2(Random.Range(0f, 5f), Random.Range(0f,5f));
            yield return new WaitForSeconds(0.1f);
        }
        if (checktime > 3f)
        {
            safeZonAlpha(0);
            checktime = 0f;
            yield break;
        }
    }
}
