using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rabbit_Dir : MonoBehaviour
{
    public StageManager SM;
    public GameObject PM;
    public GameObject Player;
    public GameObject StartWall;
    public GameObject Boss;
    public Vector3 BossVec = new Vector3(0, 0.4f, 0);
    public Vector3 CamVec = new Vector3(0f, 0.6f, -0.7f);
    public SpriteRenderer BossRenderer;
    public GameObject Cam;
    public GameObject[] SendSmoke;
    bool isDie = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        StartWall = GameObject.Find("Wall").transform.Find("BulletWallStart").gameObject;
        PM = GameObject.Find("Managers").transform.Find("patternManager").gameObject;
        SM = GameObject.Find("Managers").transform.Find("stageManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DoDie();
    }

    void DoDie()
    {
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
       
        if (SM.bossClear == true && isDie == false)
        {
            Debug.Log("¹¹¾ß");
            isDie = true;
            Player.SetActive(false);
            StartWall.SetActive(true);
            PM.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            Boss.transform.DOMove(BossVec, 0.5f);
            yield return new WaitForSeconds(0.5f);
            Cam.transform.DOMove(CamVec, 1f);
            yield return new WaitForSeconds(1f);
            StartCoroutine("Send");
            yield return new WaitForSeconds(3f);

            for (int i = 0; i < 3; i++)
            {
                BossRenderer.DOFade(1, 0.3f);
                yield return new WaitForSeconds(0.3f);
                BossRenderer.DOFade(0, 0.3f);
                yield return new WaitForSeconds(0.3f);
            }
            SM.bossClear = false;
            isDie = true;
          
        }


    }

    IEnumerator Send()
    {

        for (int n = 0; n < 1; n++)
        {
            for (int i = 0; i < 30; i++)
            {
                SendSmoke[i].SetActive(false);
                float posX = Random.Range(-2f, 2f);
                float posY = Random.Range(-1, 1.5f);
                SendSmoke[i].transform.position = new Vector3(posX, posY, 0);
                SendSmoke[i].SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
            if (n == 2)
            {
                break;
            }       
        }
        for (int i = 0; i < 30; i++)
        {
            SendSmoke[i].SetActive(false);
        }

    }
}
