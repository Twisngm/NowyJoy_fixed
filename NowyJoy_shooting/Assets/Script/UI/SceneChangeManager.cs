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
    bool isMovedUp = false;
    bool isMovedDown = false;
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
    }
    
    public void curtein_down()
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

    public void curtein_close()
    {
        StartCoroutine("curteinClosed");
    }
    public void curtein_move()
    {
        // �� ���̵��� Ŀư ����� �̵�!
        curtein_left.transform.position = new Vector2(Screen.width / 2 - (Screen.width/2), Screen.height / 2);
        curtein_right.transform.position = new Vector2(Screen.width / 2 + (Screen.width / 2), Screen.height / 2);


        //ȭ�� ����� �̵���Ŵ
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
            checkTime = 0f;
            yield break;
        }
    }

    IEnumerator curteinClosed()
    {
        while (checkTime < 2f)
        {
            checkTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            curtein_left.transform.Translate(curteinposright * speed);
            curtein_left.transform.Translate(curteinposleft * speed);
        }
        if (checkTime > 2f)
        {
            checkTime = 0f;
            yield break;
        }
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
