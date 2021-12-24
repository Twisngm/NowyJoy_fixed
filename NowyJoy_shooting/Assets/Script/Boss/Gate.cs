using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gate : MonoBehaviour
{
    public GameObject flame;
    public GateBall GB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
        flame.GetComponent<SpriteRenderer>().color = Color.white;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            // flame.GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine("FadeOut");
            GB.goalCnt++;
        }
    }

    IEnumerator FadeOut()
    {
        for (int i = 0; i < 3; i++)
        {
            flame.GetComponent<SpriteRenderer>().DOFade(0, 0.2f);
            yield return new WaitForSeconds(0.2f);
            flame.GetComponent<SpriteRenderer>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.2f);
            flame.GetComponent<SpriteRenderer>().DOFade(0, 0.2f);
        }


    }
}
