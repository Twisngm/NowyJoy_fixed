using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChangeManager : MonoBehaviour
{
    public GameObject GameExitWindow;
    Pause pause;
    public Image fadeObject;
    public GameObject Wall;
    public GameObject curtein_full;
    public GameObject curtein_left;
    public GameObject curtein_right;
    public GameObject curtein_left_close;
    public GameObject curtein_right_colse;
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

    RectTransform Close_Left_Origin_Pos;
    RectTransform Close_Right_Origin_Pos;
    RectTransform Open_Left_Origin_Pos;
    RectTransform Open_Right_Origin_Pos;
    RectTransform Top_Origin_Pos;

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
        pause = Pause.Instance;
    }

    private void Start()
    {
        Close_Left_Origin_Pos = curtein_left_close.GetComponent<RectTransform>();
        Close_Right_Origin_Pos = curtein_right_colse.GetComponent<RectTransform>();
        Open_Left_Origin_Pos = curtein_left.GetComponent<RectTransform>();
        Open_Right_Origin_Pos = curtein_right.GetComponent<RectTransform>();
        Top_Origin_Pos = curtein_full.GetComponent<RectTransform>();
        curtein_colse_L.SetActive(true);
        curtein_close_R.SetActive(true);
        curtein_transperent_Close_0();
    }

    private void Update()
    {
        ExitGame();
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
        curtein_full.GetComponent<RectTransform>().DOAnchorPosY(-2211, 3f);
        yield return new WaitForSeconds(3f);
        isMovedDown = false;
        isCurtein_Up_finished = true;
        yield break;
        /*
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
        */
    }

    IEnumerator curteinDown()
    { 
        if (SceneManager.GetActiveScene().name == "StageSelect" || SceneManager.GetActiveScene().name == "IntegratedMode")
        {
            Wall.SetActive(true);
            curtein_full.GetComponent<RectTransform>().DOAnchorPosY(5, 3f);
            yield return new WaitForSeconds(3f);
            isCurtein_Down_finished = true;
            Wall.SetActive(false);
            yield break;
            /*
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
            */
        }
        else
        {
            isMovedDown = true;
            curtein_full.GetComponent<RectTransform>().DOAnchorPosY(-2211, 3f);
            yield return new WaitForSeconds(3f);
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
            isCurtein_Down_finished = true;
            yield break;
            /*
            while (checkTime < 3.2f)
            {
                isMovedDown = true;
                checkTime += 0.1f;
                yield return new WaitForSecondsRealtime(0.1f);
                curtein_full.transform.Translate(curteinposdown * speed);
            }
            if (checkTime > 3.2f)
            {
                curtein_full = Top_Origin_Pos;
                isCurtein_Down_finished = true;
                checkTime = 0f;
                yield break;
            }
            */
        }
    }

    IEnumerator curteinOpen()
    {
        curtein_transperent_Close_100();
        curtein_full.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 3700);
        curtein_left_close.GetComponent<RectTransform>().anchoredPosition = new Vector2(-525, 0);
        curtein_right_colse.GetComponent<RectTransform>().anchoredPosition = new Vector2(525, 0);
        curtein_left_close.GetComponent<RectTransform>().DOAnchorPosX(-1450, 3f);
        curtein_right_colse.GetComponent<RectTransform>().DOAnchorPosX(1450, 3f);
        yield return new WaitForSeconds(3f);
        curtein_transperent_Close_0();
        isClosed = false;
        curtein_left_close.GetComponent<RectTransform>().anchoredPosition = Close_Left_Origin_Pos.anchoredPosition;
        curtein_right_colse.GetComponent<RectTransform>().anchoredPosition = Close_Right_Origin_Pos.anchoredPosition;
        yield break;
        /*
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
            curtein_left_close = Close_Left_Origin_Pos;
            curtein_right_colse = Close_Right_Origin_Pos;
            checkTime = 0f;
            yield break;
        }
        */
    }

    IEnumerator curteinClose()
    {
        Debug.Log("sdf");
        isClosed = true;
        curtein_left_close.GetComponent<RectTransform>().DOAnchorPosX(-525, 3f);
        curtein_right_colse.GetComponent<RectTransform>().DOAnchorPosX(525, 3f);
        yield return new WaitForSeconds(3f);
        curtein_left.GetComponent<RectTransform>().anchoredPosition = Open_Left_Origin_Pos.anchoredPosition;
        isCurtein_Close_finished = true;
        yield break;
        /*
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
            curtein_left = Open_Left_Origin_Pos;
            curtein_right = Open_Right_Origin_Pos;
            checkTime = 0f;
            isCurtein_Close_finished = true;
            yield break;
        }
        */
    }

    void curtein_transperent_Close_0()
    {
       
        /*
        Color left_color = curtein_left_close.GetComponent<Image>().color;
        Color right_color = curtein_right_colse.GetComponent<Image>().color;
        left_color.a = 0f;
        right_color.a = 0f;
        curtein_left_close.GetComponent<Image>().color = left_color;
        curtein_right_colse.GetComponent<Image>().color = right_color;
        */
    }

    void curtein_transperent_Close_100()
    {
        Color left_color = curtein_left_close.GetComponent<Image>().color;
        Color right_color = curtein_right_colse.GetComponent<Image>().color;
        left_color.a = 1f;
        right_color.a = 1f;
        curtein_left_close.GetComponent<Image>().color = left_color;
        curtein_right_colse.GetComponent<Image>().color = right_color;
    }


    public void FadeIn() // ?????? ??????.
    {
        StartCoroutine(FadeImage(true));
    }

    public void FadeOut() // ?????? ????????.
    {
        StartCoroutine(FadeImage(false));
    }
    void OnEnable()
    {
        // ?? ???????? sceneLoaded?? ?????? ????.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ?????? ?????? ?? ?????? ?? ?????? ????????.
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
        if (SceneManager.GetActiveScene().name == "IntegratedMode")
        {
            curtein_Open();
      
        }
        /*
        if (SceneManager.GetActiveScene().name == "stage1")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        */
        if (SceneManager.GetActiveScene().name == "stage2")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
   
        if (SceneManager.GetActiveScene().name == "stage3")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage4")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage5")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage6")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage7")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage8")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "stage9")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "CutScene_1")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        if (SceneManager.GetActiveScene().name == "CutScene_2")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        /*
        if (SceneManager.GetActiveScene().name == "CutScene_3")
        {
            curtein_Open();
            curtein_full.GetComponent<RectTransform>().anchoredPosition = Top_Origin_Pos.anchoredPosition;
        }
        */
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
            // loop over 1 second backwards // ?????? ??
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
        Debug.Log("?????? ????????????.");
        StartCoroutine(FadeTest(0, 1)); // ?????? ???? ????????
        testimage.color = new Color(0, 0, 0, 0);
    }

    public void FadeInTest()
    {
        Debug.Log("?????? ??????????.");
        testimage.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeTest(1, 0)); // ?????? ???? ??????
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

    public void ExitGame()
    {
        if (Input.GetKey("escape"))
        {
#if UNITY_EDITOR
            {
                GameExitWindow.SetActive(true);
                OnPause();
            }
            //  UnityEditor.EditorApplication.isPlaying = false;
#else
{
 GameExitWindow.SetActive(true);
 OnPause();
 }
       // Application.Quit(); // ???????????? ????
#endif


        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
     UnityEditor.EditorApplication.isPlaying = false;

#else
    Application.Quit(); // ???????????? ????

#endif
    }

    public void OnPause()
    {
        pause.OnPause();
    }

    public void OffPause()
    {
        pause.OffPause();
    }

}
