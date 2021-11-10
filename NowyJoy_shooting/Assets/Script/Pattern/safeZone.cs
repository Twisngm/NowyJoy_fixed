using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safeZone : MonoBehaviour
{
    public GameObject safezone;
    SpriteRenderer safezone_renderer;
    float checktime = 0f;
    float startTtime = 0f;
    float randomcreate;
    private void Start()
    {
        safezone_renderer = safezone.GetComponent<SpriteRenderer>();
        safeZoneAlpha(0);
    }
    private void Update()
    {
        startTtime += Time.deltaTime;

        if (startTtime >1f)
        {
            randomcreate = Random.Range(1, 101);
            startTtime = 0f;
            if (randomcreate <=  1) // �� �ۼ�Ʈ Ȯ���� �Ұ�����
            {
                start_safezone();
            }
        }
    }

    public void start_safezone()
    {
        StartCoroutine("showsafeZone");
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
        //float changeTime = 1f; // changeTime �Ŀ� ó�� ����
        randomPos();
        safeZoneAlpha(1);
        while (true)
        {
            checktime += Time.deltaTime;
            if (checktime > 10f)
            {
                checktime = 0f;
                safeZoneAlpha(0);
                //changeTime = Random.Range(2f, 6f);
                yield break;
            }
            yield return null;
        }
    }
}
