using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Touch touchZero; // 첫번째 터치
    private Touch touchOne; // 두번째 터치
    bool onTouch; // 터치중인지 검사하는 bool형 변수

    public Vector3 m_curPos; // 플레이어의 현재 위치
    public Vector3 m_prevPos; // 플레이어의 이전 위치
    public Vector3 gap; // 이동을 위한 변수
    Vector3 Spacepos;
    public float deltaMagnitudeDiff; // 두 손가락을 썼을 때 둘 사이의 거리를 저장하는 변수

    PolygonCollider2D Playercollider; // collider

    // 회전 관련 변수
    public float Anglespeed;
    private float axis = 0;
    public Transform target;
    public Vector3 targetPos;
    public Vector3 quaternionToTarget;
    //public float ToTarget;
    public GameObject Balloonobj;
    public Balloon balloon;
    public Quaternion targetRotation;
    public float currentangle;

    // 더블 탭에 사용되는 변수
    float lastTouchTime;
    const float doubleTapdelay = 0.5f;
    public GameObject Attacker;
    public float PBspeed;
    public float shotdelay;
    private float curshotdelay = 0;
    Transform PBtr;
    private PlayerBullet PlayerBulletcontoller;

    bool Invincible; // 무적판정 여하

    float transferspeed = 0.15f; // 크기 조정비율(inspector 기준)

    public GameObject Manager;
    public GameManager GM;
    public GameObject ptnManage;
    public bool ptntof;

    Heart heart;
    Animator anim;
    public GameObject shotEffect;
    void Start()
    {
        Spacepos = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Playercollider = GetComponent<PolygonCollider2D>();
        heart = transform.GetChild(0).GetComponent<Heart>();
        lastTouchTime = Time.time;
        PBtr = Attacker.transform;
        //Ptransform = GetComponent<Transform>();
        anim = transform.GetChild(4).GetComponent<Animator>();
        balloon = Balloonobj.GetComponent<Balloon>();
        
        GM = GameManager.GM_Instance;
        Manager = GameObject.Find("Managers");
        ptnManage = Manager.transform.Find("patternManager").gameObject;
    }
    private void OnEnable()
    {
        StartCoroutine("StartFire");
    }
    void Update()
    {
        
        OnDrag();
        //Update_LookRatation();
        //Reload();
        CameraIn();
        ptntof = checkptn();
        shotEffect.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thorn"))
        {
            heart.OnDamaged();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wiper") || collision.gameObject.CompareTag("Rabbit") || collision.gameObject.CompareTag("Bird") || collision.gameObject.CompareTag("MadHatter"))
        {
            heart.OnDamaged();
        }
    }

    void CameraIn()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);



        if (pos.x < 0f) pos.x = 0;

        if (pos.x > 1f) pos.x = 1;

        if (pos.y < 0) pos.y = 0;

        if (pos.y > 1) pos.y = 1;



        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    public void OnDrag()
    {
        if (Input.touchCount == 1) // 터치 입력이 하나일 때
        {
            touchZero = Input.GetTouch(0); // 현재 입력받은 위치를 첫번째 터치로 저장
            if (touchZero.phase == TouchPhase.Began) // 첫번째 터치의 phase가 Began(시작)이라면
            {
                onTouch = true; // onTouch를 true로 (이동 o)

                m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x * -1, Input.GetTouch(0).position.y * -1, Spacepos.z)); // 이동시키기

                /*if (Time.time - lastTouchTime < doubleTapdelay && curshotdelay > shotdelay)
                {
                    PBFire();
                }*/
            }
            else if (touchZero.phase == TouchPhase.Ended) // 첫번째 터치의 phase가 Ended(끝)이라면
            {
                onTouch = false; // onTouch를 false로 (이동 x)
                target.localPosition = Vector3.zero;
                targetPos = target.localPosition;
                //ToTarget = 0;
                quaternionToTarget = Vector3.zero;
                lastTouchTime = Time.time; // 첫번째 손가락을 뗀 순간을 마지막 터치 시간으로 저장
            }
        }
        if (Input.touchCount == 2) // 터치 입력이 두개일 때
        {
            touchZero = Input.GetTouch(0); // 첫번째 터치를 저장
            touchOne = Input.GetTouch(1); // 두번째 터치를 저장

            // 처음 터치한 위치에서 이전 프레임에서의 터치 위치와 이번 프레임에서 터치 위치의 차이를 뺌
            Vector2 touchZeroPos = touchZero.position - touchZero.deltaPosition;
            // deltaPosition : 이동방향 추적에 사용
            Vector2 touchOnePos = touchOne.position - touchOne.deltaPosition;

            //각 프레임에서 터치 사이의 벡터 거리를 구함
            float prevTouchDeltaMag = (touchZeroPos - touchOnePos).magnitude;
            // magnitude는 두 점 사이의 거리 비교(벡터)
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //거리 차이 구하기 (마이너스면 손가락을 벌린 상태)
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            /*if (deltaMagnitudeDiff > 0 && transform.localScale.x >= 0.15f)
            { // 손가락을 서로 가까이 드래그했으며 플레이어의 사이즈가 0.1 이상이라면
                transform.localScale = new Vector3(
                    transform.localScale.x - 1.0f * (transferspeed * Time.deltaTime),
                    transform.localScale.y - 1.0f * (transferspeed * Time.deltaTime),
                    0.3f); //x, y값을 줄이고 z값은 그대로

                
                //Playercollider.size = new Vector2(
                  //  Playercollider.size.x - (transferspeed * 13 * Time.deltaTime),
                    //Playercollider.size.y - (transferspeed * 16 * Time.deltaTime)
                    //);//콜라이더도 작게
                
            }
            else if (deltaMagnitudeDiff < 0 && transform.localScale.x <= 0.45f)
            { // 손가락을 서로 멀리 떨어뜨리면
                transform.localScale = new Vector3(
                    transform.localScale.x + 1.0f * (transferspeed * Time.deltaTime),
                    transform.localScale.y + 1.0f * (transferspeed * Time.deltaTime),
                    0.3f); // 플레이어 사이즈를 크게
                
                //Playercollider.size = new Vector2(
                    //Playercollider.size.x + (transferspeed * 13 * Time.deltaTime),
                    //Playercollider.size.y + (transferspeed * 16 * Time.deltaTime)
                  //  );
                
            }*/
            if (touchZero.phase == TouchPhase.Began) // 첫번째 터치의 phase가 Began(시작)이라면
            {
                    onTouch = true; // onTouch를 true로 (이동 o)
                m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x * -1, Input.GetTouch(0).position.y * -1, Spacepos.z)); // 이동시키기
                //if (Time.time - lastTouchTime < doubleTapdelay && curshotdelay > shotdelay)
                //{
                  //  PBFire();
                //}
            }
            else if (touchZero.phase == TouchPhase.Ended) // 첫번째 터치의 phase가 Ended(끝)이라면
            {
                onTouch = false; // onTouch를 false로 (이동 x)
                target.localPosition = Vector3.zero;
                targetPos = target.localPosition;
                //ToTarget = 0;
                quaternionToTarget = Vector3.zero;
                lastTouchTime = Time.time; // 첫번째 손가락을 뗀 순간을 마지막 터치 시간으로 저장
            }

        }
        
        if (onTouch && Time.timeScale != 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x * -1, Input.GetTouch(0).position.y * -1, Spacepos.z));

            m_curPos = mousePosition; // 현재 터치 위치
            gap = m_curPos - m_prevPos; // 기존 위치와 현재 위치 차 계산

            transform.position += gap; // position에 gap만큼을 추가해 이동시킴

            if (touchZero.phase != TouchPhase.Stationary)
            {
                Update_LookRatation();
            }
            else
            {
                LookZero(Anglespeed);
            }

            m_prevPos = m_curPos; // 값을 현재 위치값으로 변경
        }
        else
        {
            LookZero(Anglespeed);
        }

    }
    private void Update_LookRatation()
    {
        Vector3 myPos = transform.position; // 현재 위치
        currentangle = transform.rotation.z;
        
            target.localPosition += gap;
        if (target.localPosition.x > 1.0f)
        {
            target.localPosition = new Vector3(1.0f, 1, 0);
        }
        else if (target.localPosition.x < -1.0f)
        {
            target.localPosition = new Vector3(-1.0f, 1, 0);
        }
        

        targetPos = target.position; // target 오브젝트 위치

        Vector3 rotateDir = targetPos - myPos; // 위치 차 계산
        /*ToTarget = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(ToTarget, Vector3.forward), anglespeed * Time.deltaTime);*/

        quaternionToTarget = Quaternion.Euler(0, 0, axis) * rotateDir; // 여기부터는 어떻게 구현되는건지 잘 모르겠음
        //Quaternion
        targetRotation = Quaternion.LookRotation(Vector3.forward, quaternionToTarget);

        if (targetRotation.z <0.1f && targetRotation.z > -0.1f)
        {
            return;
        }

        if (currentangle < -0.25f && (targetRotation.z < 0.0f || targetRotation.z > 0.25f))
        {
            return;
        }
        else if (currentangle > 0.25f && targetRotation.z > 0.0f)
        {
            return;
        }
        if (currentangle > 0.15f || currentangle < -0.15f)
        {
            balloon.TransRotation(targetRotation);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Anglespeed * Time.deltaTime); // anglespeed만큼의 속도로 Rotation 변환

    }
    void PBFire() //탄환 발사
    {
        anim.Play("ShotEffect");
        GameObject PlayerBullet = Instantiate(Attacker, new Vector3(transform.position.x, transform.position.y+0.8f, transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        SoundManager.Instance.PlayattackSE("attack"); //플레이어 공격 소리
        PlayerBulletcontoller = PlayerBullet.GetComponent<PlayerBullet>();
        
        PlayerBulletcontoller.Launch(Vector2.up, PBspeed);
        //curshotdelay = 0;
    }
    void LookZero(float anglespeed)
    {
        target.localPosition = new Vector3(0, 1, 0);
        targetPos = target.localPosition;
        quaternionToTarget = Vector3.zero;
        currentangle = 0;
        targetRotation = Quaternion.LookRotation(Vector3.forward, Vector3.zero);
        balloon.TransRotation(targetRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, anglespeed * Time.deltaTime); // anglespeed만큼의 속도로 Rotation 변환
    }
    bool checkptn()
    {
       if (ptnManage.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator StartFire()
    {
        for (; ; )
        {
            if (Time.timeScale == 0)
            {
                yield return null;
            }
            else if (!ptntof)
            {
                yield return null;
            }
            else
            {
                PBFire();
            }
            yield return new WaitForSeconds(.5f);
        }
    }
    /*void Reload()
    {
        curshotdelay += Time.deltaTime;
    }*/
    /*public void Invinc()
    {
        Invincible = true;
        StartCoroutine("invinc");
    }
    IEnumerator invinc()
    {
        Playercollider.enabled = false;
        if (Invincible == false)
        {
            Playercollider.enabled = true;
            yield return null;
        }
        Invincible = false;
        yield return new WaitForSeconds(0.5f);
    }*/
}