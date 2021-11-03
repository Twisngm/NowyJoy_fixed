using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    GameManager GM;
    public ObjectManager objManager;
    public GameObject Spin_ptn;
    public bool isPatterning = false;
  
    // 패턴

    public Transform[] PatternPos;
    public GameObject[] testobj;

    // 타겟팅 패턴
    GameObject target;
    public Transform bulletPos;  
    public float BulletAspeed;
    public float shootSpeed_target;
  
    // 스핀샷 패턴
  
    public float shootSpeed_spin;

    // 도형 패턴
   
    [Range(0, 360), Tooltip("퍼지기 전 회전을 줄 수 있음")]  //초기 중심 : 회전 되는 방향
    public float rot = 0f;

    [Range(3, 7), Tooltip("퍼지는 모양이 몇각형으로 퍼질지 정하는 것")] //->삼~칠각형이 그나마 이쁨 그 이상으로 가면 원으로 보임..
    public int Vertex = 3;

    [Range(1, 5), Tooltip("이 값을 조정하여 둥근 느낌, 납작한 느낌으로 표현 됨")]
    public float sup = 3;

    //스피드
    public float shootSpeed_Shape = 3;//탄속
    public float shootSpeed_shapping; //연사

    //생성위치
    public GameObject[] shapePos = new GameObject[4];
    public GameObject[] Warning = new GameObject[4];
    public  bool[] isAble_Shape = new bool[4];
    int Direction;
    int Count = 0;

    // 플라밍고 패턴

    public GameObject flamingo;
    public GameObject thorn;
    public GameObject[] flaPos;
    public bool[] isAble_Flamingo;

    // 체스 폰 패턴

    public GameObject[] pawn;
    public GameObject Warning_Pawn;
    public Warning_Pawn WarnPawn;
    public Warning_Under_Pawn WarnUnderPawn;

    //기타 데이터들
    int m;
    float a;
    float phi;
    List<float> v = new List<float>();
    List<float> xx = new List<float>();

    // 화면 크기 조절 패턴
    public GameObject cam;
    public float[] camZ;

    // 거울 패턴
    public GameObject player;
    public GameObject heart;
    public GameObject centerLine;
    public GameObject Mirror;
    public Vector3 ClonePos;
    public Vector3 PlayerPos;
    public GameObject Warning_Mirror;

    // 와이퍼 패턴
    public GameObject Wiper_Ver;
    public GameObject Wiper_Hor;
    public GameObject Warning_Wiper_Ver;
    public GameObject Warning_Wiper_Hor;
    public float Wiper_Speed;

    // 레이저 패턴
    public GameObject Laserer;
    public GameObject Laser;
    public GameObject Warning_Laser;
    public float rotateSpeed;
    public float LaserSpeed;

    public GameObject NowyJoy;
    Title title;

    private void Awake()
    {
        //   title = GameObject.Find("Trigger").GetComponent<Title>();
        GM = GameObject.Find("gameManager").GetComponent<GameManager>();
        target = GameObject.FindWithTag("Player");
        shapePos[0] = GameObject.Find("bulletPos_U");
        shapePos[1] = GameObject.Find("bulletPos_D");
        shapePos[2] = GameObject.Find("bulletPos_R");
        shapePos[3] = GameObject.Find("bulletPos_L");
        for(int i = 0; i < isAble_Shape.Length; i++)
        {
            isAble_Shape[i] = true;
        }
        ShapeInit();
        InitCamZ();
    }



    private void OnEnable()
    {

        StartCoroutine("Shooting");
    //    Invoke("DoPattern", 5f);
        DoPtn();

    }

    private void OnDisable()
    {
        CancelInvoke("DoPtn");
    }
    private void Update()
    {

        if(isPatterning)
        {
            shootSpeed_target = 2.5f;
        }
        else if(!isPatterning)
        {
            shootSpeed_target = 5f;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine("Flamingo");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
         //   NowyJoyCtrl();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(LaserPattern(PatternPos[Random.Range(0,8)]));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            startWiper(PatternPos[Random.Range(0,8)]);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shapeShooting();
        }
        if(Count == 4)
        {
            for(int i = 0; i < isAble_Shape.Length; i++)
            {
                isAble_Shape[i] = true;
                isAble_Flamingo[i] = true;
            }
            Count = 0;
        }
    }



    void InitCamZ()
    {
        int index = 0;
        for (float i = 0.6f; i <= 1.2f; i += 0.05f)
        {
            camZ[index] = i * (-1);
            index++;
        }
    }

    public void DoPattern()
    {
        int index = Random.Range(0, 4);
        Debug.Log(index);
        /// 0 : 플라밍고
        /// 1 : 스핀
        /// 2 : 5각형
        /// 3 : 폰
        if(index == 0)
        {
            StartCoroutine("Flamingo");
        }
        else if(index == 1)
        {
            StartCoroutine("spin");
        }
        else if(index == 2)
        {
            shapeShooting();
        }
        else if(index == 3)
        {
            StartCoroutine("PawnDrop");
        }
       
       
    }
    
    public void DoPtn()
    {
        int[] randPos = new int[2];
        Transform[] ptnPos = new Transform[2];
        int[] randPtn = new int[8];

        do
        {
            randPos[0] = Random.Range(0, 8);
            randPos[1] = Random.Range(0, 8);
        }
        while (randPos[0] == randPos[1]);

        ptnPos[0] = PatternPos[randPos[0]];
        ptnPos[1] = PatternPos[randPos[1]];

        do
        {
            randPtn[0] = Random.Range(0, 3);
            randPtn[1] = Random.Range(0, 1);
        }
        while (randPtn[0] == randPtn[1]);


        switch (randPtn[0])
        {
            case 0:
                Screen_Scale_Control();
                break;

            case 1:
                StartMirror();
                break;

            case 2:
                StartCoroutine("Flamingo");
                break;

            case 3:
                StartCoroutine(test4(ptnPos[0]));
                break;

            case 4:
                StartCoroutine(test5(ptnPos[0]));
                break;

            case 5:
                StartCoroutine(test6(ptnPos[0]));
                break;

            case 6:
                StartCoroutine(test7(ptnPos[0]));
                break;

            case 7:
                StartCoroutine(test8(ptnPos[0]));
                break;
        }

        
        switch (randPtn[1])
        {
            case 0:
                if(GM.stagenum != 1)
                    startWiper(ptnPos[1]);

                else
                    shapeShooting();

                break;

            case 1:
                StartCoroutine("spin");
                break;

            case 2:
                shapeShooting();
                break;

            case 3:

                if(GM.stagenum != 1)
                    StartCoroutine("PawnDrop");

                else
                    StartCoroutine("spin");

                break;

            case 4:
                startLaser(ptnPos[1]);
                break;

            case 5:
                StartCoroutine(test6(ptnPos[1]));
                break;

            case 6:
                StartCoroutine(test7(ptnPos[1]));
                break;

            case 7:
                StartCoroutine(test8(ptnPos[1]));
                break;

        }
        Invoke("DoPtn", 10f);
    }

    IEnumerator test1(Transform pos)
    {
        testobj[0].transform.position = pos.position;
        testobj[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[0].SetActive(false);
    }

    IEnumerator test2(Transform pos)
    {
        testobj[1].transform.position = pos.position;
        testobj[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[1].SetActive(false);
    }

    IEnumerator test3(Transform pos)
    {
        testobj[2].transform.position = pos.position;
        testobj[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[2].SetActive(false);
    }

    IEnumerator test4(Transform pos)
    {
        testobj[3].transform.position = pos.position;
        testobj[3].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[3].SetActive(false);
    }

    IEnumerator test5(Transform pos)
    {
        testobj[4].transform.position = pos.position;
        testobj[4].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[4].SetActive(false);
    }
    IEnumerator test6(Transform pos)
    {
        testobj[5].transform.position = pos.position;
        testobj[5].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[5].SetActive(false);
    }

    IEnumerator test7(Transform pos)
    {
        testobj[6].transform.position = pos.position;
        testobj[6].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[6].SetActive(false);
    }

    IEnumerator test8(Transform pos)
    {
        testobj[7].transform.position = pos.position;
        testobj[7].SetActive(true);
        yield return new WaitForSeconds(3f);
        testobj[7].SetActive(false);
    }

 

    public IEnumerator spin()
    {
       
            StartCoroutine("spinning");
            isPatterning = true;
        yield return new WaitForSeconds(2.5f);
            StopCoroutine("spinning");
              isPatterning = false;
           
        
    }

    void ShapeInit()
    {
        //요소들이 들어 있을 수 있으니 초기화 하기전에 Clear한다.
        v.Clear();
        xx.Clear();

        //데이터 초기화
        m = (int)Mathf.Floor(sup / 2);
        a = 2 * Mathf.Sin(Mathf.PI / Vertex);
        phi = ((Mathf.PI / 2f) * (Vertex - 2f)) / Vertex;
        v.Add(0);
        xx.Add(0);

        for (int i = 1; i <= m; i++)
        {
            //list.Insert(위치,요소) -> 해당 위치에 값을 집어넣습니다.
            v.Add(Mathf.Sqrt(sup * sup - 2 * a * Mathf.Cos(phi) * i * sup + a * a * i * i));
        }

        for (int i = 1; i <= m; i++)
        {
            xx.Add(Mathf.Rad2Deg * (Mathf.Asin(a * Mathf.Sin(phi) * i / v[i])));
        }
    }

    public IEnumerator shapeShoot()
    {
       
        //rot값에 영향을 주지 않도록 별도로 dir값을 선언하였다.
        var dir = rot;

        while (true)
        {

            Direction = Random.Range(0, 4);

            if (isAble_Shape[Direction] == true)
                break;

        }

        isAble_Shape[Direction] = false;

     // Warning[Direction].transform.position = shapePos[Direction].transform.position;
        Warning[Direction].SetActive(true);
        yield return new WaitForSeconds(1.25f);
        Warning[Direction].SetActive(false);


        //꼭짓점 수 만큼 실행
        for (int r = 0; r < Vertex; r++)
        {
            for (int i = 1; i <= m; i++)
            {
 
                #region //1차 생성
                //총알 생성
                GameObject idx1 = objManager.MakeObj("bulletC");

                //총알 생성 위치를 (0,0) 좌표로 한다.
                idx1.transform.position = shapePos[Direction].transform.position;
               

                //정밀한 회전 처리로 모양을 만들어 낸다.
                idx1.transform.rotation = Quaternion.Euler(0, 0, dir + xx[i]);

                //정밀한 속도 처리로 모양을 만들어 낸다.
                idx1.GetComponent<BulletC>().speed = v[i] * shootSpeed_Shape / sup;
                #endregion

                #region //2차 생성
                //총알 생성
                GameObject idx2 = objManager.MakeObj("bulletC");


               

                //총알 생성 위치를 (0,0) 좌표로 한다.
                idx2.transform.position = shapePos[Direction].transform.position;

                //정밀한 회전 처리로 모양을 만들어 낸다.
                idx2.transform.rotation = Quaternion.Euler(0, 0, dir - xx[i]);

                //정밀한 속도 처리로 모양을 만들어 낸다.
                idx2.GetComponent<BulletC>().speed = v[i] * shootSpeed_Shape / sup;
                #endregion

                #region //3차 생성
                //총알 생성
                GameObject idx3 = objManager.MakeObj("bulletC");


               

                //총알 생성 위치를 (0,0) 좌표로 한다.
                idx3.transform.position = shapePos[Direction].transform.position;

                //정밀한 회전 처리로 모양을 만들어 낸다.
                idx3.transform.rotation = Quaternion.Euler(0, 0, dir);

                //정밀한 속도 처리로 모양을 만들어 낸다.
                idx3.GetComponent<BulletC>().speed = shootSpeed_Shape;
                #endregion

                //모양을 완성한다.
                dir += 360 / Vertex;
            }
        }
        Count++;
    }

    public void shapeShooting()
    {
      
        StartCoroutine("shapeSht");

      
    }

 


    IEnumerator Shooting()
    {
        
        while (true)
        {
            int Direction = Random.Range(0, 4);
            float width = Random.Range(-5f, 5f);
            float height = Random.Range(-7f, 7f);

            if(Direction == 0)
            {
                bulletPos.transform.position = new Vector2(width, 6);
            }
            else if(Direction == 1)
            {
                bulletPos.transform.position = new Vector2(width, -6);
            }
            else if (Direction == 2)
            {
                bulletPos.transform.position = new Vector2(-3.5f, height);
            }
            else if (Direction == 3)
            {
                bulletPos.transform.position = new Vector2(3.5f, height);
            }

            GameObject bulletA = objManager.MakeObj("bulletA");
            bulletA.transform.position = bulletPos.transform.position;


            Rigidbody2D rigid = bulletA.GetComponent<Rigidbody2D>();
            Vector3 dir = target.transform.position - bulletA.transform.position;

            rigid.AddForce(dir.normalized * BulletAspeed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(3f / shootSpeed_target);
        }
    }

    IEnumerator spinning()
    {
        while (true)
        {
          
            //총알 생성
            GameObject temp = objManager.MakeObj("bulletB");

            //총알 생성 위치를 머즐 입구로 한다.
            temp.transform.position = Spin_ptn.transform.position;

            //총알의 방향을 오브젝트의 방향으로 한다.
            //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
            temp.transform.rotation = Spin_ptn.transform.rotation;
            yield return new WaitForSeconds(1f / (shootSpeed_spin * 10));
        }
    }

    IEnumerator shapeSht()
    {
        isPatterning = true;
        int cnt = 0;
        while (cnt < 4)
        {
            StartCoroutine("shapeShoot");   
            yield return new WaitForSeconds(1.25f);
            cnt++;
        }
        isPatterning = false;
       

    }
    public IEnumerator Flamingo()
    {
        int cnt = 0;
        isPatterning = true;
        while (cnt < 2)
        {
            while (true)
            {

                Direction = Random.Range(0, 4);

                if (isAble_Flamingo[Direction] == true)
                    break;

            }

            isAble_Flamingo[Direction] = false;

            Warning[Direction].SetActive(true);
            yield return new WaitForSeconds(1f);
            Warning[Direction].SetActive(false);

            flamingo.SetActive(true);
            thorn.SetActive(true);

            float randPosX = Random.Range(-0.75f, 0.75f);
            float randPosY = Random.Range(-3.2f, 3.2f);
            yield return new WaitForSeconds(0.1f);
            if (Direction == 0)
            {
                flamingo.transform.position = new Vector2(randPosX, flaPos[Direction].transform.position.y);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 180);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("y", -5.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 1)
            {
                flamingo.transform.position = new Vector2(randPosX, flaPos[Direction].transform.position.y);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 0);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("y", 5.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 2)
            {
                flamingo.transform.position = new Vector2(flaPos[Direction].transform.position.x, randPosY);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, 90);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("x", -3.5f, "time", 3.5f, "easeType", "Linear"));
            }
            else if (Direction == 3)
            {
                flamingo.transform.position = new Vector2(flaPos[Direction].transform.position.x, randPosY);
                flamingo.transform.rotation = Quaternion.Euler(0, 0, -90);
                yield return new WaitForSeconds(0.1f);
                iTween.MoveTo(flamingo, iTween.Hash("x", 3.5f, "time", 3.5f, "easeType", "Linear"));
            }
            Count++;
            cnt++;
            yield return new WaitForSeconds(3.5f);
            flamingo.SetActive(false);
            thorn.SetActive(false);

        }
        isPatterning = false;
       
    }

    IEnumerator PawnDrop()
    {
        isPatterning = true;
        int cnt = 0;
        while(cnt < 3)
        {
            float PosX = Random.Range(-2f, 2f);
            float PosY = Random.Range(3.5f, -4f);
            pawn[cnt].transform.position = new Vector2(PosX, 6);
            WarnPawn.target = pawn[cnt];
            Warning_Pawn.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            Warning_Pawn.gameObject.SetActive(false);
    
            iTween.MoveTo(pawn[cnt], iTween.Hash("y", PosY, "time", 1.5f, "easeType", "EaseOutBounce")); // 폰 드랍
            cnt++;
            if (cnt == 3)
                break;
            yield return new WaitForSeconds(1.75f); // 다음 폰 떨구는 시간
        }
        yield return new WaitForSeconds(1.5f); // 돌진 대기 시간

        int direction = Random.Range(0, 2);

        if(direction == 0)
        {
            for (int i = 0; i < 3; i++)
                WarnUnderPawn.Warning_UI[i].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction == 1)
        {
            for (int i = 0; i < 3; i++)
                WarnUnderPawn.Warning_UI[i].transform.rotation = Quaternion.Euler(0, 0, 180);
        }


        for (int i = 0; i < 3; i++)
            WarnUnderPawn.Warning_UI[i].SetActive(true);

        yield return new WaitForSeconds(1.5f); // 경고창 띄우는 시간

        for (int i = 0; i < 3; i++)
            WarnUnderPawn.Warning_UI[i].SetActive(false);



        int dir = direction == 0 ? 1 : -1;
      
            for (int i =0; i<3; i++)
            {
                iTween.MoveTo(pawn[i], iTween.Hash("x",  4 * dir, "time", 1.5f, "easeType", "EaseInOutBack")); // 폰 돌진
            }
        yield return new WaitForSeconds(1.5f); 
        isPatterning = false;

 


    }

    void Screen_Scale_Control() // 화면 크기 조절
    {
        int randSSC = Random.Range(0, 12); // 화면 크기 랜덤 추첨
        //   cam.transform.position = new Vector3(0,0,camZ[randSSC]);
        isPatterning = true;
        iTween.MoveTo(cam, iTween.Hash("z", camZ[randSSC], "time", 0.5f, "easeType", "Linear"));
        Invoke("Screen_Scale_Init", 4f); // 초기화 함수 발동
    }
    void Screen_Scale_Init() // 화면 크기 초기화
    {
        iTween.MoveTo(cam, iTween.Hash("z", -1, "time", 0.5f, "easeType", "Linear"));
        isPatterning = false;
    }

    void StartMirror()
    {
        StartCoroutine("mirrorPnt");
    }


    IEnumerator mirrorPnt() // 거울 패턴
    {
        isPatterning = true;
        // 경고표시

        Warning_Mirror.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Warning_Mirror.SetActive(false);

        // 플레이어 비활성화

        player.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1f);
        player.SetActive(false);

        // 중앙선 드랍

        centerLine.SetActive(true);
        iTween.MoveTo(centerLine, iTween.Hash("z", 0, "time", 1.5f, "easeType", "EaseOutBounce"));

        // 플레이어 활성화 및 분열

        yield return new WaitForSeconds(2f);
        Mirror.SetActive(true);
        GameObject playerClone = objManager.MakeObj("playerClone"); // 클론 생성
        player.SetActive(true);
        playerClone.transform.position = ClonePos;
        player.transform.position = PlayerPos;

        playerClone.GetComponent<Animator>().SetTrigger("In");
        player.GetComponent<Animator>().SetTrigger("In");


        // 거울 패턴 종료

        yield return new WaitForSeconds(4f);

        iTween.MoveTo(centerLine, iTween.Hash("x", -10, "time", 1f, "easeType", "Linear"));

        playerClone.GetComponent<Animator>().SetTrigger("Out");

        yield return new WaitForSeconds(1f);
        centerLine.SetActive(false);
        centerLine.transform.position = new Vector3(0, 0, -1.5f);
        playerClone.SetActive(false);
        Mirror.SetActive(false);
        isPatterning = false;

        //   Invoke("StartMirror", 10f);
    }
   void startWiper(Transform Pos)
    {
        StartCoroutine(WiperPattern(Pos));
    }
    IEnumerator WiperPattern(Transform Pos)
    {
        isPatterning = true;
        if((Pos.position == new Vector3(3.3f,0)) || (Pos.position == new Vector3(-3.3f, 0))) // 좌우 와이퍼
        {
            /// 경고표시
            if (Pos.position.x > 0)
                Warning[2].SetActive(true);
            else
                Warning[3].SetActive(true);
            yield return new WaitForSeconds(1f);
            if (Pos.position.x > 0)
                Warning[2].SetActive(false);
            else
                Warning[3].SetActive(false);
            ///
            Warning_Wiper_Hor.SetActive(true); // 활성화
            Wiper_Hor.SetActive(true);
            yield return new WaitForSeconds(0.005f);
            Wiper_Hor.transform.position = Pos.position; // 위치 설정
            Wiper_Hor.transform.rotation = Quaternion.Euler(0, 0, 90);
            iTween.RotateTo(Wiper_Hor, iTween.Hash("z", Pos.position.x > 0 ? 270 : -90 , "time", Wiper_Speed, "easeType", "Linear"));
            yield return new WaitForSeconds(Wiper_Speed);
            Wiper_Hor.SetActive(false); // 비활성화
            Warning_Wiper_Hor.SetActive(false);

        }
        
        else if(Pos.position.y != 0) // 상하 와이퍼
        {
            if (Pos.position.x == 0) // 중심
            {
                /// 경고표시
                if (Pos.position.y > 0)
                    Warning[0].SetActive(true);
                else
                    Warning[1].SetActive(true);
                yield return new WaitForSeconds(1f);
                if (Pos.position.y > 0)
                    Warning[0].SetActive(false);
                else
                    Warning[1].SetActive(false);
                ///
               
                Warning_Wiper_Ver.SetActive(true); // 활성화
                Wiper_Ver.SetActive(true);
                yield return new WaitForSeconds(0.005f);
                Wiper_Ver.transform.position = Pos.position; // 위치 설정
                Wiper_Ver.transform.rotation = Quaternion.Euler(0, 0, 180);
                iTween.RotateTo(Wiper_Ver, iTween.Hash("z", Pos.position.y > 0 ? 360 : 0, "time", Wiper_Speed, "easeType", "Linear"));
                yield return new WaitForSeconds(Wiper_Speed);
                Wiper_Ver.SetActive(false); // 비활성화
                Warning_Wiper_Ver.SetActive(false);
            }
            else // 모서리
            {
                /// 경고표시
                if (Pos.position.x > 0)
                {
                    if (Pos.position.y > 0)
                        Warning[4].SetActive(true);
                    else
                        Warning[5].SetActive(true);
                }
                else
                {
                    if (Pos.position.y > 0)
                        Warning[6].SetActive(true);
                    else
                        Warning[7].SetActive(true);
                }
                    
                yield return new WaitForSeconds(1f);
                if (Pos.position.x > 0)
                {
                    if (Pos.position.y > 0)
                        Warning[4].SetActive(false);
                    else
                        Warning[5].SetActive(false);
                }
                else
                {
                    if (Pos.position.y > 0)
                        Warning[6].SetActive(false);
                    else
                        Warning[7].SetActive(false);
                }

                ///
               
                Warning_Wiper_Ver.SetActive(true); // 활성화
                Wiper_Ver.SetActive(true);
                yield return new WaitForSeconds(0.005f);
                Wiper_Ver.transform.position = Pos.position; // 위치 설정
                Wiper_Ver.transform.rotation = Quaternion.Euler(0, 0, Pos.position.x > 0 ? 180 : 0);
                iTween.RotateTo(Wiper_Ver, iTween.Hash("z", (Pos.position.x > 0 ? 1 : 180) * (Pos.position.y > 0 ? -1 : 1) , "time", Wiper_Speed * 1.5f, "easeType", "Linear"));
                yield return new WaitForSeconds(Wiper_Speed);
                Wiper_Ver.SetActive(false); // 비활성화
                Warning_Wiper_Ver.SetActive(false);
                isPatterning = false;
            }
        }

    }
    void startLaser(Transform Pos)
    {
        StartCoroutine(LaserPattern(Pos));
    }
    IEnumerator LaserPattern(Transform Pos)
    {
        float height = 0;
        float time = 0;

        isPatterning = true;
        Laser.transform.localScale = new Vector2(Laser.transform.localScale.x, 0);
        Laserer.SetActive(true);
        Warning_Laser.SetActive(true);
        Laserer.transform.position = Pos.position;
        while (time <= 1) /// 플레이어 조준 기능
        {
            
            if (player != null)
            {
                Vector2 direction = new Vector2(
                    Laserer.transform.position.x - player.transform.position.x,
                    Laserer.transform.position.y - player.transform.position.y
                );

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(Laserer.transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
                Laserer.transform.rotation = rotation;
                time += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }


        } ///
        Warning_Laser.SetActive(false);

        while (height <= 1) /// 레이저 발사 기능
        {
            height += LaserSpeed / 100;
            Laser.transform.localScale = new Vector3(height, 1 , 1);
            yield return new WaitForSeconds(0.001f);
        } ///

        yield return new WaitForSeconds(1f);
        Laserer.SetActive(false);
        isPatterning = false;

    }


    /*
     *
     * public GameObject Teledoor1;
       public GameObject Teledoor2;
       public GameObject Player;
       public GameObject dodo; //보스
       // in Start()
       BoxCollider2D Telecoll1 = Teledoor1.collider;
       BoxCollider2D Telecoll2 = Teledoor2.collider;
       Transform Tetr1 = Teledoor1.Transform;
       Transform Tetr2 = Teledoor2.Transform;
       Trnasform Pltr = Player.Transform;
       Transform Bosstr = dodo.Transform;
     */
    /*public void Teleporter{
     * int Gate = Random.Range(0, 4);
     * if (Gate == 0){
     *      Tetr1.position = (a1, b1, c1);
     *      Tetr2.position = (d1, e1, f1);
     * }
     * else if (Gate == 1){
     *      Tetr1.position = (a2, b2, c2);
     *      Tetr2.position = (d2, e2, f2);
     * }
     * else if (Gate == 2){
     *      Tetr1.position = (a3, b3, c3);
     *      Tetr2.position = (d3, e3, f3);
     * }
     * else if (Gate == 3){
     *      Tetr1.position = (a4, b4, c4);
     *      Tetr2.position = (d4, e4, f4);
     * }
     * 
     * if (Telecoll1.gameObject.layer == 6){
     *      Pltr.position = Tetr2.position;
     * }
     * if (Telecoll2.gameObject.layer == 6){
     *      Pltr.position = Tetr1.position;
     * }
     * }
     */

}
