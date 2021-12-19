using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThistleTrigger : MonoBehaviour
{
    public Dog dog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dog.SetThistle();
            this.gameObject.SetActive(false);
        }
    }
}
