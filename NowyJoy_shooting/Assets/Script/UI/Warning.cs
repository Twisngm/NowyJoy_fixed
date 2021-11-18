using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    GameObject gaugeObj;
    Image gauge;

    private void Awake()
    {
        gaugeObj = transform.Find("!").gameObject;
        gauge = gaugeObj.GetComponent<Image>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine("fillGauge");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fillGauge()
    {
        gauge.fillAmount = 0;
        while(gauge.fillAmount <= 1)
        {
            gauge.fillAmount += 0.015f;
            yield return new WaitForSeconds(0.01f); // ¾à 0.66 ÃÊ
        }
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
}
