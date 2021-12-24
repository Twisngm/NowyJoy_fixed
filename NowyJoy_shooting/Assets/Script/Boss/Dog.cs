using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dog : MonoBehaviour
{

    public GameObject Thistle;
    public GameObject ThistleTri;
    public GameObject Player;
    public ObjectManager objManager;
    public GameObject[] Rains;
    public GameObject BackSmoke;
    public GameObject Back;
    Rigidbody2D rigid;
    bool isCol = false;
    public bool isRush = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        DoPattern();
        StartCoroutine("Return");
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.velocity.y >= 1)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, 1,0f);
        }
        if(isRush)
        {
            rigid.AddForce(Vector3.down * 1 * Time.deltaTime, ForceMode2D.Impulse);
            BackSmoke.SetActive(true);
            Back.SetActive(true);
        }
        else
        {
            BackSmoke.SetActive(false);
            Back.SetActive(false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Thistle")
        {
            isCol = true;
        }
    }


    void DoPattern()
    {
        int index;
        index = Random.Range(0, 2);

        switch(index)
        {
            case 0:
                StartCoroutine("Rush");
                break;

            case 1:
                StartCoroutine("Shake");
                break;
           
                    
        }
    }

    IEnumerator Rush()
    {
        transform.DOMoveY(6, 1.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(2f);
        isRush = true;
        ThistleTri.SetActive(true);
        ThistleTri.transform.position = new Vector2(Random.Range(-2,2), Random.Range(2,-3.5f));
        StartCoroutine("BulletShot");
        yield return new WaitForSeconds(10f);
        StartCoroutine("DoPattern");
    }
   public  void SetThistle()
    {
        Thistle.transform.DOMove(new Vector3(0.4f, Player.transform.position.y + 1.5f, 0), 0.5f);
    }

    IEnumerator BulletShot()
    {
        while(isRush)
        {
            GameObject bullet_R = objManager.MakeObj("bulletA");
            GameObject bullet_L = objManager.MakeObj("bulletA");

            bullet_R.transform.position = new Vector2(transform.position.x,transform.position.y - 0.3f) ;       
            bullet_L.transform.position = new Vector2(transform.position.x,transform.position.y - 0.3f);

            Rigidbody2D BulletRigid_R = bullet_R.GetComponent<Rigidbody2D>();
            Rigidbody2D BulletRigid_L = bullet_L.GetComponent<Rigidbody2D>();

            BulletRigid_R.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
            BulletRigid_L.AddForce(Vector2.left * 2, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);

        }
        StopCoroutine("BulletShot");
    }

    IEnumerator Return()
    {
        if(isCol)
        {
            isRush = false;
            transform.DOMoveY(2.85f, 2f);
            isCol = false;
            ThistleTri.SetActive(false);
            ThistleTri.transform.position = new Vector3(7.5f, 0, 0);
            Thistle.transform.DOMove(new Vector3(10f, 0f, 0f), 2f);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);      
        }
        StartCoroutine("Return");
    }

    IEnumerator Shake()
    {
        int fir;
        int[] sec = new int[2];

        fir = Random.Range(0, 2);
        if(fir == 0)
        {
            sec[0] = Random.Range(0, 5);
            do
            {
                sec[1] = Random.Range(0, 5);
            }
            while (sec[0] == sec[1]);
            Rains[sec[0]].GetComponent<UbhShotCtrl>().StartShotRoutine();
            Rains[sec[1]].GetComponent<UbhShotCtrl>().StartShotRoutine();
            yield return new WaitForSeconds(5f);
            Rains[sec[0]].GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
            Rains[sec[1]].GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
        }
        else if(fir == 1)
        {
            sec[0] = Random.Range(5, 7);
            Rains[sec[0]].GetComponent<UbhShotCtrl>().StartShotRoutine();
            yield return new WaitForSeconds(5f);
            Rains[sec[0]].GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine("DoPattern");
    }
}
