using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hedgehog : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("chase", 3f);
    }
    private void OnDisable()
    {
        CancelInvoke("chase");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void chase()
    {
        transform.DOMove(target.transform.position, 1.5f);
        Invoke("chase", 3f);
    }
}
