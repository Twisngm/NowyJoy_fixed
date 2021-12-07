using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card_Soldier : MonoBehaviour
{
    public Vector3 vec;
    public GameObject Smoke;
    public GameObject Card;
    // Start is called before the first frame update

    public void Execute()
    {
        gameObject.transform.position = new Vector3(4.4f, 0.4f, 0);
        gameObject.SetActive(true);
        StartCoroutine("Execution");
    }

    IEnumerator Execution()
    { 
        float moveTime = 2.5f;
        transform.DOMove(vec, moveTime);
        yield return new WaitForSeconds(moveTime);
        Smoke.GetComponent<Animator>().Play("Smoke");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Card.GetComponent<UbhShotCtrl>().StartShotRoutine();
        yield return new WaitForSeconds(0.1f);
        Card.GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
    }

    }
