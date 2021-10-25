using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Zone : MonoBehaviour
{

    public GameObject Timer;
  
    Animator anim;
  

    // Start is called before the first frame update
    void Start()
    {
        anim = Timer.GetComponent<Animator>();
    }

    // Update is called once per frame
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            anim.Play("Out");
            // anim.SetTrigger("Out");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            anim.Play("In");
            // anim.SetTrigger("In");
        }
    }
  
  
}
