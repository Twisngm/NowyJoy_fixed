using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hedgehog : MonoBehaviour
{
    public float time;
    public GameObject target;
    public float rotateSpeed;

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine("chase");
    }
    private void OnDisable()
    {
        StopCoroutine("chase");
    }
    // Update is called once per frame
    void Update()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
        }
    }

    IEnumerator chase()
    {
        time = 3;   
        while(true)
        {
            Vector2 direction = new Vector2(transform.position.x - target.transform.position.x,
                transform.position.y - target.transform.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
            yield return new WaitForSeconds(0.001f);
            if(time <= 0)
            {
                break;
            }
        }
        transform.DOMove(target.transform.position, 1.5f);
        yield return new WaitForSeconds(3f);
        StartCoroutine("chase");
    }
}
