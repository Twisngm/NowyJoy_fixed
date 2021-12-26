using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss_Trigger_Bird : MonoBehaviour
{

    public Time_UI time;
    public GameObject PM;
    public GameObject Bird;
    public GameObject owl;
    public GameObject Wall;
    public GameObject Cam;
    public Pause pause;
    public GameObject player;
    public GameObject Ui;
    public RectTransform[] direction;
    public Text BossName;
    public bool isAppear = false;

    private void Start()
    {
        Wall = GameObject.Find("Wall").transform.Find("BulletWallStart").gameObject;
        pause = GameObject.Find("Pause").GetComponent<Pause>();
        player = GameObject.Find("Player");
        Ui = GameObject.Find("UI");
        direction[0] = GameObject.Find("direction").transform.Find("UP").GetComponent<RectTransform>();
        direction[1] = GameObject.Find("direction").transform.Find("Down").GetComponent<RectTransform>();
        BossName = GameObject.Find("direction").transform.Find("Name").GetComponent<Text>();
        PM = GameObject.Find("Managers").transform.Find("patternManager").gameObject;


        StartCoroutine("Appear");
    }

    // Update is called once per frame
    void Update()
    {
        // BossTrigger();
    }
    IEnumerator Appear()
    {
        if (time.min <= 0)
            StartCoroutine("Appearance");
        else
        {
            yield return new WaitForSeconds(0.1f * Time.deltaTime);
            StartCoroutine("Appear");
           
        }
    }
    /*
    void BossTrigger()
    {
        if (time.min <= 0)
        {        
          for(int i = 0; i < Boss.Length; i++)
            {
                Boss[i].SetActive(true);
                PM.isBoss = true;
                
            }
            
        }
    }
    */
    IEnumerator Appearance()
    {
        Debug.Log("¹¹¾ß");
        Cam.transform.DOMove(new Vector3(0.06f, 0.6f, -0.7f), 1f);
        direction[0].DOAnchorPosY(1, 1);
        direction[1].DOAnchorPosY(0, 1);
        Wall.SetActive(true);
        player.SetActive(false);
        Ui.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        BossName.DOFade(1, 1f);
        Bird.SetActive(true);
        owl.SetActive(true);
        PM.GetComponent<PatternManager>().isBoss = true;
        Bird.transform.DOMoveY(0.4f, 3f);
        yield return new WaitForSeconds(2.9f);
   //     Time.timeScale = 0;
   //     yield return new WaitForSeconds(1f);
   //     Time.timeScale = 1;
        player.transform.position = new Vector3(0, -3.15f, 0);
        player.SetActive(true);
        Wall.SetActive(false);
        Ui.SetActive(true);
        Cam.transform.DOMove(new Vector3(0f, 0f, -1f), 0.5f);
        BossName.DOFade(0, 0.5f);
        direction[0].DOAnchorPosY(128, 0.5f);
        direction[1].DOAnchorPosY(-128, 0.5f);
        // pause.isPause = false;

    }
}
