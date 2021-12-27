using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingMove : MonoBehaviour
{
    Vector2 settingposdown = new Vector2(0, -2f);
    Vector2 settingposup = new Vector2(0, 3f);
    public float speed = 10f;
    public Button btn, hidebtn;
    bool isMovedUp = false;
    bool isMovedDown = false;

    void Start()
    {
        btn.onClick.AddListener(movingDown);
        hidebtn.onClick.AddListener(movingUp);
    }

    void movingUp()
    {
        isMovedUp = true;
        StartCoroutine("settingMovingUp");
    }

    void movingDown()
    {
        isMovedDown = true;
        StartCoroutine("settingMovingdown");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StopTrigger"))
        {
            if (isMovedDown)
            {
                StopCoroutine("settingMovingdown");
                isMovedDown = false;
            }
            else if (isMovedUp)
            {
                StopCoroutine("settingMovingUp");
                isMovedUp = false;
            }
            
        }
    }
    IEnumerator settingMovingUp()
    {

        this.gameObject.GetComponent<RectTransform>().DOAnchorPosY(2000f, 1f);


        yield return null;

        /*
        while (true)
        {
            yield return new WaitForSecondsRealtime(0f);
            transform.Translate(settingposup * speed);
        }
        */
    }

    IEnumerator settingMovingdown()
    {
        this.gameObject.GetComponent<RectTransform>().DOAnchorPosY(0f, 1f);

        yield return null;
        /*
        while (true)
        {
            yield return new WaitForSecondsRealtime(0f);
            transform.Translate(settingposdown * speed);
        }
        */
    }

}
