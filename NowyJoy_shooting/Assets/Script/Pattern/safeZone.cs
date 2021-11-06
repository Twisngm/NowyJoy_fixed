using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safeZone : MonoBehaviour
{
    public GameObject safezone;
    SpriteRenderer safezone_renderer;
    float checktime = 0f;

    private void Start()
    {
        safezone_renderer = safezone.GetComponent<SpriteRenderer>();
        safeZoneAlpha(0);
        start_safezone();
    }


    public void start_safezone()
    {
        StartCoroutine("showsafeZone");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("주인공과 닿았습니다.");
        }
    }

    void safeZoneAlpha(int alphaCount)
    {
        Color safezone_color = safezone_renderer.color;
        if (alphaCount == 1)
        {
            safezone_color.a = 1;
            safezone_renderer.color = safezone_color;
        }
        else
        {
            safezone_color.a = 0;
            safezone_renderer.color = safezone_color;
        }
    }

    void randomPos()
    {
        safezone.transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-4f, 4f));
    }
    IEnumerator showsafeZone()
    {
        float changeTime = 1f;
        while (true)
        {
            checktime += 0.1f;
            if (checktime > changeTime)
            {
                safeZoneAlpha(1);
                checktime = 0f;
                randomPos();
                changeTime = Random.Range(2f, 6f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
