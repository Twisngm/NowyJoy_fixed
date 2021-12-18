using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeMove : MonoBehaviour
{
    public Image GaugeImg;
    bool isGaugeFull = false;
    public int currentValue;
    int maxValue = 100;
    public int GotoScene;

    private void FixedUpdate()
    {
        if (isGaugeFull)
        {
            ChangeScenes();
        }
    }
    public void ChangeScenes()
    {
        switch (GotoScene)
        {
            case 1:
                SceneManager.LoadScene(4);
                break;
            case 2:
                SceneManager.LoadScene(5);
                break;
            case 3:
                SceneManager.LoadScene(6);
                break;
            case 4:
                SceneManager.LoadScene(7);
                break;
            case 5:
                SceneManager.LoadScene(8);
                break;
            case 6:
                SceneManager.LoadScene(9);
                break;
        }
    }

    public void Add(int val)
    {
        currentValue += val;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
            isGaugeFull = true;
        }
        GaugeImg.fillAmount = Normalise();
    }

    private float Normalise()
    {
        return (float)currentValue / maxValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("addgauge");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("addgauge");
    }

    IEnumerator addgauge()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);

            Add(2);
        }
    }
}