using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float anglespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TransRotation(Quaternion tempRotation)
    {
        tempRotation.z = -tempRotation.z + tempRotation.z / 3.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, tempRotation, anglespeed * Time.deltaTime);
    }
}
