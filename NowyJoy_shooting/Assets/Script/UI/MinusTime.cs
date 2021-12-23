using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MinusTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine("Minus");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Minus()
    {
        transform.GetComponent<SpriteRenderer>().DOFade(0, 1.5f);
        transform.DOMove(new Vector2(Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f), Random.Range(transform.position.y +0.5f, transform.position.y + 1f)),0.2f);
    //    transform.DOScale(new Vector2(0, 0), 1.5f);
    //    transform.DOMoveY(transform.position.x + 1f, 1.5f);

        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        transform.position = new Vector3(1.38f, 4, 0);
        transform.GetComponent<SpriteRenderer>().DOFade(1, 0.01f);
        transform.localScale = new Vector3(0.07f, 0.07f, 1);
        
    }
}
