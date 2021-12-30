using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss_Trigger_Dog : MonoBehaviour
{
    public GameObject Dog;
    public GameObject Wall;
    public GameObject Cam;
    public Pause pause;
    public GameObject player;
    public GameObject Ui;
    public RectTransform[] direction;
    public Text BossName;
    public GameObject PM;


    private void OnEnable()
    {
        Wall = GameObject.Find("Wall").transform.Find("BulletWallStart").gameObject;
        pause = GameObject.Find("Pause").GetComponent<Pause>();
        player = GameObject.Find("Player");
        Ui = GameObject.Find("UI");
        direction[0] = GameObject.Find("direction").transform.Find("UP").GetComponent<RectTransform>();
        direction[1] = GameObject.Find("direction").transform.Find("Down").GetComponent<RectTransform>();
        BossName = GameObject.Find("direction").transform.Find("Name").GetComponent<Text>();
        PM = GameObject.Find("Managers").transform.Find("patternManager").gameObject;
        Appear();
    }
    public void Appear()
    {
        StartCoroutine("Appearance");
    }

    IEnumerator Appearance()
    {

        Cam.transform.DOMove(new Vector3(0.06f, 1.2f, -0.7f), 1f);
        direction[0].DOAnchorPosY(1, 1);
        direction[1].DOAnchorPosY(0, 1);
        Wall.SetActive(true);
        player.SetActive(false);
        Ui.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        BossName.DOFade(1, 1f);
        Dog.SetActive(true);
        Dog.transform.DOMoveY(0.4f, 3f);
        yield return new WaitForSeconds(2.9f);
    /*    Time.timeScale = 0;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;*/
        player.transform.position = new Vector3(0, -3.15f, 0);
        player.SetActive(true);
        Wall.SetActive(false);
        Ui.SetActive(true);
        Cam.transform.DOMove(new Vector3(0f, 0f, -1f), 0.5f);
        BossName.DOFade(0, 0.5f);
        direction[0].DOAnchorPosY(128, 0.5f);
        direction[1].DOAnchorPosY(-128, 0.5f);
        PM.SetActive(true);
        // pause.isPause = false;

    }
}
