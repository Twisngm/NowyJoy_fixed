using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Fade : MonoBehaviour
{
    public GameObject PM;
    public SpriteRenderer Player;
    public Text StageTxt;
    public LetterSpacing Txt;
    public GameObject StartWall;
    public GameObject SetOnObj;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        StageTxt = GameObject.Find("StageText").GetComponentInChildren<Text>();
        Txt = GameObject.Find("StageText").GetComponentInChildren<LetterSpacing>();
        StartWall = GameObject.Find("Wall").transform.Find("BulletWallStart").gameObject;
        PM = GameObject.Find("Managers").transform.Find("patternManager").gameObject;

        //

        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        StartWall.SetActive(true);
        Player.sortingOrder = 100;
        Time.timeScale = 0;
        yield return new WaitForSeconds(1.5f);
        transform.GetComponent<Image>().DOFade(0, 1f); 
        
        StageTxt.DOFade(1, 1);
        Txt.spacing = -10;
        while(Txt.spacing <= 20)
        {
            Txt.spacing += 0.075f;
            yield return new WaitForSeconds(0.001f * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.5f);
        Player.sortingOrder = 1;
        StageTxt.GetComponentInChildren<Text>().DOFade(0, 1).OnComplete(GameStart);
        Time.timeScale = 1;
        transform.gameObject.SetActive(false);
        PM.SetActive(true);
    }

   void GameStart()
    {
        StartWall.SetActive(false);
        SetOnObj.SetActive(true);
       
    }
}
