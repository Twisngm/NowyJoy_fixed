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
        StartCoroutine("Execution");
    }

    IEnumerator Execution()
    {
        float moveTime = 1.5f;
        transform.DOMove(vec, moveTime);
        yield return new WaitForSeconds(moveTime);
        Smoke.GetComponent<Animator>().Play("Smoke");
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
        Card.GetComponent<UbhShotCtrl>().StartShotRoutine();
        yield return new WaitForSeconds(0.1f);
        Card.GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
    }

    }
