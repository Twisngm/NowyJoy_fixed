using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadHatter : MonoBehaviour
{
    public GameObject[] Hat = new GameObject[3];
    public GameObject[] Arrow = new GameObject[3];
    public Hat[] hat;
    public float moveSpeed;
    bool isFollow = false;
    public GameObject Timer;
    public float FollowTime;
    public float time;
    bool isStart = false;
    public UbhShotCtrl wrong;
    public bool isAble = false; 
    public int rand;
    public int[] randPos;
//    public GameObject Smoke;
    List<float> PosIndex = new List<float>() { 0, -1.7f, 1.7f };
    public PatternManager PM;
    public GameObject Player;
    public StageManager SM;
    GameObject Effect;
    Animator anim;
    Animator Anim;
    PolygonCollider2D col;

    void Start()
    {
        // StartCoroutine("Jump");
     //  DoPattern();
        
        Effect = GameObject.Find("Blood");
        anim = Effect.GetComponent<Animator>();
        Anim = GetComponentInChildren<Animator>();
        col = GetComponentInChildren<PolygonCollider2D>();
        SM = GameObject.Find("Managers").transform.Find("stageManager").GetComponent<StageManager>();
    }
    private void OnEnable()
    {
        StartCoroutine("Appear");
    }
    IEnumerator Appear()
    {
        PM.isBoss = true;
        iTween.MoveTo(this.gameObject, iTween.Hash("y", 0.5f, "time", 3f, "easeType", "Linear"));
        yield return new WaitForSeconds(5f);
        DoPattern();
    }
    private void Update()
    {
        if (!SM.bossClear)
        {
            FollowTimeCount();

            StopFollow();

            DeathCount();

            stopDeathCount();

            SetArrow();
        }
        if (this.gameObject.transform.position.z < -0.05)
            OffCollider();

        else
            OnCollider();

        if (SM.bossClear)
        {
            StopAllCoroutines();
            CancelInvoke("DoPattern");
        }
    }
    void DoPattern()
    {
        int rand = Random.Range(1, 100);

        if (rand >= 1 && rand <= 50)
            StartCoroutine("Hat_In");

        else if (rand >= 51 && rand <= 75)
            StartCoroutine("Jump");

        else if (rand >= 76 && rand <= 100)
            startFollow();

    }

    void OnCollider()
    {
        col.enabled = true;
    }

    void OffCollider()
    {
        col.enabled = false;

    }

    void CreateUnDuplicateRandom()
    {
        List<int> Index = new List<int>();
        int currentNumber = Random.Range(0, 3);

        for (int i =0; i<3;)
        {

            if (Index.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, 3);
            }
            else
            {
                Index.Add(currentNumber);
                randPos[i] = currentNumber;
                i++;
            }
        }
    }

    IEnumerator Hat_In()
    {
        isStart = true;
        CreateUnDuplicateRandom();
        Anim.SetTrigger("Smile");
        iTween.MoveTo(gameObject, iTween.Hash("y", 2f, "time", 1f, "easeType", "Linear"));
        
        yield return new WaitForSeconds(1f);
        Hat[0].SetActive(true);
        iTween.MoveTo(Hat[0], iTween.Hash("position", new Vector3(PosIndex[randPos[0]],0.8f,0), "time", 0.5f, "easeType", "Linear"));
        yield return new WaitForSeconds(0.15f);

        Hat[1].transform.position = Hat[0].transform.position;
        Hat[1].SetActive(true);
        iTween.MoveTo(Hat[1], iTween.Hash("position", new Vector3(PosIndex[randPos[1]], 0.8f,0), "time", 0.3f, "easeType", "Linear"));
        yield return new WaitForSeconds(0.15f);

        Hat[2].transform.position = Hat[0].transform.position;
        Hat[2].SetActive(true);
        iTween.MoveTo(Hat[2], iTween.Hash("position", new Vector3(PosIndex[randPos[2]], 0.8f,0), "time", 0.3f, "easeType", "Linear"));
        isAble = true;
   

        Yabawi();
    }
   public void RightStart()
    {
        StartCoroutine("Right");
    }
    IEnumerator Right()
    {
        isStart = false;
        Debug.Log("????");
        iTween.MoveTo(Hat[0], iTween.Hash("position", new Vector3(0, 6, 0), "time", 1f, "easeType", "Linear"));
        yield return new WaitForSeconds(0.2f);
        iTween.MoveTo(Hat[1], iTween.Hash("position", new Vector3(0, 6, 0), "time", 1f, "easeType", "Linear"));
        yield return new WaitForSeconds(0.2f);
        iTween.MoveTo(Hat[2], iTween.Hash("position", new Vector3(0, 6, 0), "time", 1f, "easeType", "Linear"));
        yield return new WaitForSeconds(1.5f);
        iTween.MoveTo(gameObject, iTween.Hash("y", 0.8f, "time", 1f, "easeType", "Linear"));

        isAble = false;

        yield return new WaitForSeconds(5f);
        DoPattern();
    }
   public void WrongStart()
    {
        StartCoroutine("Wrong");
    }
    IEnumerator Wrong()
    {
        Debug.Log("????");
        wrong.StartShotRoutine();
        yield return new WaitForSeconds(1f);
        wrong.StopShotRoutineAndPlayingShot();
           
    }

    void Yabawi()
    {

        rand = Random.Range(0, 3);
        Debug.Log(rand);
     
    }

    void SetArrow()
    {
        if (isAble)
        {
            for (int i = 0; i < Arrow.Length; i++)
            {
                Arrow[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Arrow.Length; i++)
            {
                Arrow[i].SetActive(false);
            }
        }
    }

    void DeathCount()
    {
        if (isStart)
            time += Time.deltaTime;
    }

    void stopDeathCount()
    {
        if (time >= 5)
        {
            RightStart();
            Effect.transform.position = Player.transform.position;
            anim.Play("SmokeFX4");
            if (GameManager.GM_Instance.Perfectmode == false)
            {
                GameManager.GM_Instance.HP -= 5;
            }
            time = 0;
           
        }
    }

    IEnumerator Jump()
    {
        float next = 2.75f;

        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Jump1"), "speed", 2f,"delay", 2f, "easeType", iTween.EaseType.easeOutBounce, "movetopath", false));
        yield return new WaitForSeconds(next + 0.5f);
   //     Smoke.transform.position = this.gameObject.transform.position;
   //     Smoke.transform.position += new Vector3(0,0.5f,0);
   //     Smoke.GetComponent<Animator>().Play("Smoke");
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Jump2"), "speed", 3f, "delay", 2f, "easeType", iTween.EaseType.easeOutBounce, "movetopath", false));
        yield return new WaitForSeconds(next);
   //     Smoke.transform.position = this.gameObject.transform.position;
   //     Smoke.transform.position += new Vector3(0, 0.5f, 0);
   //     Smoke.GetComponent<Animator>().Play("Smoke");
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Jump3"), "speed", 3f, "delay", 2f, "easeType", iTween.EaseType.easeOutBounce, "movetopath", false));
        yield return new WaitForSeconds(next);
   //     Smoke.transform.position = this.gameObject.transform.position;
   //     Smoke.transform.position += new Vector3(0, 0.5f, 0);
   //     Smoke.GetComponent<Animator>().Play("Smoke");
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Jump4"), "speed", 3f, "delay", 2f, "easeType", iTween.EaseType.easeOutBounce, "movetopath", false));
        yield return new WaitForSeconds(next);
   //     Smoke.transform.position = this.gameObject.transform.position;
   //     Smoke.transform.position += new Vector3(0, 0.5f, 0);
   //     Smoke.GetComponent<Animator>().Play("Smoke");
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath("Jump5"), "speed", 2f, "delay", 2f, "easeType", iTween.EaseType.easeOutBounce, "movetopath", false));
        yield return new WaitForSeconds(next);
   //     Smoke.transform.position = this.gameObject.transform.position;
   //     Smoke.transform.position += new Vector3(0, 0.5f, 0);
   //     Smoke.GetComponent<Animator>().Play("Smoke");
        yield return new WaitForSeconds(next);
        DoPattern();
    }
    void startFollow()
    {
        isFollow = true;
        Timer.SetActive(true);
        Anim.SetTrigger("Follow");
    }

    void FollowTimeCount()
    {
        if (isFollow)
        {
            FollowTime -= Time.deltaTime;
            Follow();
        }

    }

    void StopFollow()
    {
        if (FollowTime <= 0)
        {
            isFollow = false;
            Timer.SetActive(false);
            iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(0, -0.5f, 0), "time", 1f, "easeType", "Linear"));
            FollowTime = 10;
            Invoke("DoPattern", 5f);
        }
    }
    void Follow()
    {    
        if(isFollow)
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

}
