using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject player;
 
    private void FixedUpdate()
    {
        gameObject.transform.position = player.transform.position;
    }
}
