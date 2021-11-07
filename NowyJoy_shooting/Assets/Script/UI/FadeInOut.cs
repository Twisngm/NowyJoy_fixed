using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image fadeObject;
    [Range(0.01f, 10f)]
    public float fadeTime = 1f;
    public AnimationCurve fadeCurve;

    private static FadeInOut instance;

    public static FadeInOut Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FadeInOut>();
            }
            return instance;
        }
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = fadeObject.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            fadeObject.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
}
