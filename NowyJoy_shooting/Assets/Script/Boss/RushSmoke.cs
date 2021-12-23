using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushSmoke : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Back")
        {
            StartCoroutine("Smoke");
        }
    }

    IEnumerator Smoke()
    {
        yield return new WaitForSeconds(0.5f);
        anim.Play("Smoke");
    }
}
