using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushCard : MonoBehaviour
{
    public GameObject[] StartPos = new GameObject[8];
    public GameObject Target;
    public GameObject Warning;

    public float rotateSpeed;
    public float moveSpeed;
    public float cooltime;


    bool isRush = false;


    public void Rush()
    {
        StartCoroutine("Rushing");
    }

    private void Update()
    {

        if (isRush)
            gameObject.transform.localPosition += gameObject.transform.up * moveSpeed * Time.deltaTime * -1;
    }

    IEnumerator Rushing()
    {
        float time = 0;

        gameObject.transform.position = StartPos[Random.Range(0, 8)].transform.position;
        gameObject.SetActive(true);
        Warning.SetActive(true);
        while (time <= 1) /// 플레이어 조준 기능
        {

            if (Target != null)
            {
                Vector2 direction = new Vector2(
                    gameObject.transform.position.x - Target.transform.position.x,
                    gameObject.transform.position.y - Target.transform.position.y
                );

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(gameObject.transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
                gameObject.transform.rotation = rotation;
                time += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        Warning.SetActive(false);
        isRush = true;


        yield return new WaitForSeconds(5f);
        isRush = false;

      
    }
}
