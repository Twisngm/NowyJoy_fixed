using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public Image fadeObject;
    public Image curtein_full;
    public Image curtein_left;
    public Image curtein_right;
    public Image curtein_left_close;
    public Image curtein_right_colse;
    public GameObject curtein_colse_L;
    public GameObject curtein_close_R;
    Vector2 curteinposdown = new Vector2(0, -7f);
    Vector2 curteinposup = new Vector2(0, 8f);
    Vector2 curteinposleft = new Vector2(-5f, 0);
    Vector2 curteinposright = new Vector2(5f, 0);
    public float speed = 6f;
    bool isDown = false;
    bool isMovedDown = false;
    bool isClosed = false;
    bool isColsed_close = false;
    float checkTime = 0f;

    Vector2 Close_Left_Origin_Pos;
    Vector2 Close_Right_Origin_Pos;
    Vector2 Open_Left_Origin_Pos;
    Vector2 Open_Right_Origin_Pos;
    Vector2 Top_Origin_Pos;

    [Range(0.01f, 10f)]
    public float fadeTime = 1f;
    public Image testimage;
    private FadeState fadeState;
    public AnimationCurve fadeCurve;

    private static SceneChangeManager instance;

    public static SceneChangeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneChangeManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        
    }

    private void Start()
    {
        Close_Left_Origin_Pos = curtein_left_close.transform.position;
        Close_Right_Origin_Pos = curtein_right_colse.transform.position;
        Open_Left_Origin_Pos = curtein_left.transform.position;
        Open_Right_Origin_Pos = curtein_right.transform.position;
        Top_Origin_Pos = curtein_full.transform.position;
        curtein_colse_L.SetActive(true);
        curtein_close_R.SetActive(true);
        curtein_transperent_Close_0();
    }

     void curtein_DownUp()
    {
        if (isMovedDown)
        {
            StartCoroutine("curteinUp");
        }
        else
        {
            StartCoroutine("curteinDown");
        }
    }

    public void curtein_Up()
    {
        if (!isMovedDown)
        {
            curtein_full.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
            StartCoroutine("curteinUp");
        }
        else
        {
            StartCoroutine("curteinUp");
        }
    }

    public void curtein_Down()
    {
            StartCoroutine("curteinDown");
    }

    public void curtein_Open()
    {
        curtein_transperent_Close_100();
        StartCoroutine("curteinOpen");
    }

    public void curtein_Close()
    {
        StartCoroutine("curteinClose");
    }

    void curtein_move_test()
    {
        // �� ���̵��� Ŀư ����� �̵�!
        //curtein_left.transform.position = new Vector2(Screen.width / 2 - (Screen.width/2), Screen.height / 2);
        //curtein_right.transform.position = new Vector2(Screen.width / 2 + (Screen.width / 2), Screen.height / 2);
        //curtein_right.transform.position = new Vector2((Screen.width/2)-4f,Screen.height / 2);
        //curtein_left.transform.position = new Vector2((Screen.width/2)+4f, Screen.height/2);


        //ȭ�� ����� �̵���Ŵ
        //curtein_full.transform.position = new Vector2(Screen.width/2, Screen.height/2);
    }

    IEnumerator curteinDown()
    {
        while (checkTime < 3.1f)
        {
            isMovedDown = true;
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_full.transform.Translate(curteinposdown * speed);
        }
        if (checkTime > 3.1f)
        {
            curtein_full.transform.position = Top_Origin_Pos;
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinUp()
    {
        while (checkTime < 3f)
        {
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_full.transform.Translate(curteinposup * speed);
        }
        if (checkTime > 3f)
        {
            isMovedDown = false;
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinClose()
    {
        while (checkTime < 2f)
        {
            isClosed = true;
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_left.transform.Translate(curteinposright * speed);
            curtein_right.transform.Translate(curteinposleft * speed);
        }
        if (checkTime > 2f)
        {
            curtein_left.transform.position = Open_Left_Origin_Pos;
            curtein_right.transform.position = Open_Right_Origin_Pos;
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinOpen()
    {
        while (checkTime < 2f)
        {
            curtein_transperent_Close_100();
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_right_colse.transform.Translate(curteinposright * speed);
            curtein_left_close.transform.Translate(curteinposleft * speed);
        }
        if (checkTime > 2f)
        {
            curtein_transperent_Close_0();
            isClosed = false;
            curtein_left_close.transform.position = Close_Left_Origin_Pos;
            curtein_right_colse.transform.position = Close_Right_Origin_Pos;
            checkTime = 0f;
            yield break;
        }
    }


    void curtein_transperent_Close_0()
    {
        Color left_color = curtein_left_close.color;
        Color right_color = curtein_right_colse.color;
        left_color.a = 0f;
        right_color.a = 0f;
        curtein_left_close.color = left_color;
        curtein_right_colse.color = right_color;
    }

    void curtein_transperent_Close_100()
    {
        Color left_color = curtein_left_close.color;
        Color right_color = curtein_right_colse.color;
        left_color.a = 1f;
        right_color.a = 1f;
        curtein_left_close.color = left_color;
        curtein_right_colse.color = right_color;
    }




    public void FadeIn() // ȭ���� ���δ�.
    {
        StartCoroutine(FadeImage(true));
    }

    public void FadeOut() // ȭ���� �������.
    {
        StartCoroutine(FadeImage(false));
    }
    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            FadeImage(true);
            //Invoke("FadeIn", 0.1f);
        }
        if (SceneManager.GetActiveScene().name == "ModeSelect")
        {
            FadeIn();
        }
        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            fadeObject.color = new Color(0, 0, 0, 1);
            FadeIn();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards // ���̵� ��
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeObject.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }

        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeObject.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }




    public void FadeOutTest()
    {
        Debug.Log("ȭ���� ��ο����ϴ�.");
        StartCoroutine(FadeTest(0, 1)); // ȭ���� ���� ��ο���
        testimage.color = new Color(0, 0, 0, 0);
    }

    public void FadeInTest()
    {
        Debug.Log("ȭ���� ������ϴ�.");
        StartCoroutine(FadeTest(1, 0)); // ȭ���� ���� �����
    }



    IEnumerator FadeTest(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = testimage.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            testimage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
}
