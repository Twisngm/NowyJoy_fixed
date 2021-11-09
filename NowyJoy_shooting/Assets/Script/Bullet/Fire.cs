using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        anim.Play("HitEffect");
        Invoke("Disable", 0.7f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
