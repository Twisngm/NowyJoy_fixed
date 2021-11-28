using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject RushWarning;
    public GameObject[] SendSmoke;
    public GameObject cam;
    public GameObject rain;
    PolygonCollider2D col;
    SpriteRenderer Renderer;
    Animator anim;
    UbhShotCtrl rainshot;
    public PatternManager PM;
    public GameObject Smoke;
    public GameObject Shadow;
   
    private void Awake()
    {
        col = GetComponentInChildren<PolygonCollider2D>();
        anim = GetComponentInChildren<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
        rainshot = rain.GetComponent<UbhShotCtrl>();
       
        
    }

    void OnEnable()
    {    
        StartCoroutine("Appear");
    }
    private void Update()
    {
   
        if (this.gameObject.transform.position.z < -0.15)

            OffCollider();

        else
            OnCollider();
    }

    void DoPattern()
    {
        int rand = Random.Range(1, 101);

        if(rand >= 1 && rand <= 50)
            StartCoroutine("Dash");

        else if(rand >= 51 && rand <= 75)
            StartCoroutine("Shake");

        else if(rand >= 76 && rand <= 100)
            StartCoroutine("Send");

    }

    void OnCollider()
    {
        col.enabled = true;
    }

    void OffCollider()
    {
        col.enabled = false;

    }

    IEnumerator Appear()
    {
        PM.isBoss = true;
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 0.75f, "time", 3f,"easeType","Linear"));
        yield return new WaitForSeconds(5f);
        DoPattern();
    }

    IEnumerator Dash()
    {
        int RandDir = Random.Range(0, 2);

        float DashSpeed = 2f;
     
        float warningTime = 0.1f;

        anim.SetTrigger("Step");
        yield return new WaitForSeconds(3f);


        switch (RandDir)
        {
            /*
            case 0: // 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 90);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
             //   Renderer.flipY = true;
                iTween.MoveTo(this.gameObject, iTween.Hash("y", 7, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);
                Renderer.flipY = false;
                break;

            case 1: // 오른쪽
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 0);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
                Renderer.flipX = true;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", 5, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);       
                break;
            */
            case 0: // 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 270);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
                iTween.MoveTo(this.gameObject, iTween.Hash("y", -7, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);      
                break;
/*
            case 3: // 왼쪽
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 180);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
                Renderer.flipX = false;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", -5, "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);       
                break;

            case 4: // 오른쪽 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 60);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
            //    Renderer.flipY = true;
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(3.3f, 6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);
                Renderer.flipY = false;
                break;
*/
            case 1: // 오른쪽 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 300);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
                Renderer.flipX = true;
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(3.3f, -6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);              
                break;

            case 2: // 왼쪽 아래
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 240);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
                Renderer.flipX = false;
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(-4f, -6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);
                break;
/*
            case 7: // 왼쪽 위
                RushWarning.transform.rotation = Quaternion.Euler(0, 0, 120);
                RushWarning.SetActive(true);
                yield return new WaitForSeconds(warningTime);
                RushWarning.SetActive(false);
              //  Renderer.flipY = true;
                iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(-3.5f, 6, 0), "time", DashSpeed, "easeType", "EaseInOutBack"));
                yield return new WaitForSeconds(DashSpeed);
                Renderer.flipY = false;
                break;
*/
            default:
                break;

        }
        Shadow.SetActive(true);
        Shadow.GetComponent<Animator>().Play("Shadow");
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = new Vector3(0, 0.75f, -0.8f);
        iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, 0.75f, 0), "speed", 2f, "easeType", "EaseOutBack"));
        Shadow.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Smoke.GetComponent<Animator>().Play("Smoke");
        yield return new WaitForSeconds(0.5f);

        Invoke("DoPattern", 3f);
    }

    IEnumerator Send()
    {
        anim.SetTrigger("Send");
        iTween.MoveTo(cam, iTween.Hash("z", -1.2f, "time", 1f));
        for (int n = 0; n < 3; n++)
        {
            for (int i = 0; i < 30; i++)
            {
                SendSmoke[i].SetActive(false);
                float posX = Random.Range(-2.6f, 2.6f);
                float posY = Random.Range(-5, 5);
                SendSmoke[i].transform.position = new Vector3(posX, posY, 0);
                SendSmoke[i].SetActive(true);
                yield return new WaitForSeconds(0.05f);
            }
            if(n==2)
            {
                break;
            }
            anim.SetTrigger("Send");
        }
        for (int i = 0; i < 30; i++)
        {
            SendSmoke[i].SetActive(false);
        }
        iTween.MoveTo(cam, iTween.Hash("z", -1f, "time", 1f));
        Invoke("DoPattern", 3f);
    }

    IEnumerator Shake()
    {
        anim.SetTrigger("Shake");
        rainshot.StartShotRoutine();

        yield return new WaitForSeconds(2f);
        rainshot.StopShotRoutineAndPlayingShot();

        Invoke("DoPattern", 3f);
    }

}
