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
    Vector2 curteinposdown = new Vector2(0, -3f);
    Vector2 curteinposup = new Vector2(0, 3f);
    Vector2 curteinposleft = new Vector2(-2f,0);
    Vector2 curteinposright = new Vector2(2f, 0);
    public float speed = 6f;
    bool isDown = false;
    bool isMovedDown = false;
    bool isClosed = false;
    float checkTime = 0f;

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

        curtein_transperent_OpenClose_0();
    }
    private void Start()
    {
        curtein_Close();
    }
    public void curtein_DownUp()
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

    public void curtein_OpenClose()
    {
        if (isClosed)
        {
            StartCoroutine("curteinOpen");
        }
        else
        {
            StartCoroutine("curteinClose");
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
        if (!isMovedDown)
        {
            StartCoroutine("curteinDown");
        }   
    }

    public void curtein_Down_replace()
    {
        Invoke("curtein_replace_UpDpwn", 0.1f);
        Invoke("curtein_Down_active", 2.2f);
    }
    private void curtein_replace_UpDpwn()
    {
        Color full_color = curtein_full.color;
        full_color.a = 0f;
        curtein_full.color = full_color;
        isDown = false;
        StartCoroutine("curteinUp");
    }
    private void curtein_Down_active()
    {
        Color full_color = curtein_full.color;
        full_color.a = 1f;
        curtein_full.color = full_color;
    }

    public void curtein_Open()
    {
        if (isClosed)
        {
            StartCoroutine("curteinOpen");
        }
        else
        {
            Debug.Log("이미 열려있습니다.");
        }
        
    }

    public void curtein_Close()
    {
        if (!isClosed)
        {
            StartCoroutine("curteinClose");
        }
        
    }
    public void curtein_transperent_OpenClose_0()
    {
        Color left_color = curtein_left.color;
        Color right_color = curtein_right.color;
        left_color.a = 0f;
        right_color.a = 0f;
        curtein_left.color = left_color;
        curtein_right.color = right_color;
    }

    public void curtein_transperent_OpenClose_100()
    {
        Color left_color = curtein_left.color;
        Color right_color = curtein_right.color;
        left_color.a = 1f;
        right_color.a = 1f;
        curtein_left.color = left_color;
        curtein_right.color = right_color;
    }
    public void curtein_move()
    {
        // 양 사이드의 커튼 가운데로 이동!
        //curtein_left.transform.position = new Vector2(Screen.width / 2 - (Screen.width/2), Screen.height / 2);
        //curtein_right.transform.position = new Vector2(Screen.width / 2 + (Screen.width / 2), Screen.height / 2);
        //curtein_right.transform.position = new Vector2((Screen.width/2)-4f,Screen.height / 2);
        //curtein_left.transform.position = new Vector2((Screen.width/2)+4f, Screen.height/2);


        //화면 가운데로 이동시킴
        //curtein_full.transform.position = new Vector2(Screen.width/2, Screen.height/2);
    }

    IEnumerator curteinDown()
    {
        while (checkTime <2f)
        {
            isMovedDown = true;
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_full.transform.Translate(curteinposdown * speed);
        }
        if (checkTime > 2f)
        {
            isDown = true;
            Invoke("curtein_Down_replace", 0.2f);
            //curtein_Down_replace();
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinUp()
    {
        while (checkTime < 2f)
        {
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_full.transform.Translate(curteinposup * speed);
        }
        if (checkTime > 2f)
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
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinOpen()
    {
        while (checkTime < 2f)
        {

            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_right.transform.Translate(curteinposright * speed);
            curtein_left.transform.Translate(curteinposleft * speed);
        }
        if (checkTime > 2f)
        {
            isClosed = false;
            checkTime = 0f;
            yield break;
        }
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




    public void FadeOutTest()
    {
        Debug.Log("화면이 어두워집니다.");
        StartCoroutine(FadeTest(0, 1)); // 화면이 점점 어두워짐
        testimage.color = new Color(0, 0, 0, 0);
    }

    public void FadeInTest()
    {
        Debug.Log("화면이 밝아집니다.");
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
