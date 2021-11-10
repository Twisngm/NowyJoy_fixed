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

    public bool isCurtein_Up_finished = false;
    public bool isCurtein_Down_finished = false;
    public bool isCurtein_Open_finished = false;
    public bool isCurtein_Close_finished = false;

    bool isCurtein_Up_Moving = false;
    bool isCurtein_Down_Moving = false;
    bool isCurtein_Open_Moving = false;
    bool isCurtein_Close_Moving = false;
    float checkTime = 0f;

    Vector2 Close_Left_Origin_Pos;
    Vector2 Close_Right_Origin_Pos;
    Vector2 Open_Left_Origin_Pos;
    Vector2 Open_Right_Origin_Pos;
    Vector2 Top_Origin_Pos;

    [Range(0.01f, 10f)]
    public float fadeTime = 1f;
    public Image testimage;
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
            isCurtein_Up_finished = true;
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinDown()
    { 
        if (SceneManager.GetActiveScene().name == "StageSelect")
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
                isCurtein_Down_finished = true;
                checkTime = 0f;
                yield break;
            }
        }
        else
        {
            while (checkTime < 3.2f)
            {
                isMovedDown = true;
                checkTime += 0.1f;
                yield return new WaitForSecondsRealtime(0.1f);
                curtein_full.transform.Translate(curteinposdown * speed);
            }
            if (checkTime > 3.2f)
            {
                curtein_full.transform.position = Top_Origin_Pos;
                isCurtein_Down_finished = true;
                checkTime = 0f;
                yield break;
            }
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
            isCurtein_Close_finished = true;
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


    public void FadeIn() // 화면이 보인다.
    {
        StartCoroutine(FadeImage(true));
    }

    public void FadeOut() // 화면이 까매진다.
    {
        StartCoroutine(FadeImage(false));
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "ModeSelect")
        {
            curtein_Open();
        }
        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            curtein_Open();
        }
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            curtein_Open();
            curtein_full.transform.position = Top_Origin_Pos;
        }
        if (SceneManager.GetActiveScene().name == "stage2")
        {
            curtein_full.transform.position = Top_Origin_Pos;
        }
        if (SceneManager.GetActiveScene().name == "stage3")
        {
            curtein_full.transform.position = Top_Origin_Pos;
        }
        if (SceneManager.GetActiveScene().name == "stage4")
        {
            curtein_full.transform.position = Top_Origin_Pos;
        }
        if (SceneManager.GetActiveScene().name == "Stage5")
        {
            curtein_full.transform.position = Top_Origin_Pos;
        }
        if (SceneManager.GetActiveScene().name == "Stage6")
        {
            curtein_full.transform.position = Top_Origin_Pos;
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
            // loop over 1 second backwards // 페이드 인
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

    public void fadeinscripttest()
    {
        FadeInOut.Instance.FadeIn();
    }

    public void fadeoutscripttest()
    {
        FadeInOut.Instance.FadeOut();
    }


    public void FadeOutTest()
    {
        Debug.Log("화면이 어두워집니다.");
        StartCoroutine(FadeTest(0, 1)); // 화면이 점점 어두워짐
        testimage.color = new Color(0, 0, 0, 0);
    }

    public void FadeInTest()
    {
        Debug.Log("화면이 밝아집니다.");
        testimage.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeTest(1, 0)); // 화면이 점점 밝아짐
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
