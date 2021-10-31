using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float anglespeed = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TransRotation(Quaternion targetRotation)
    {
        Quaternion tempRotation;
        tempRotation = targetRotation;
        if (targetRotation.z <= 15 && targetRotation.z >=-15) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, tempRotation, anglespeed * Time.deltaTime);
            return;
        }
        else{
            if (targetRotation.z > 15)
            {
                tempRotation.z = 15;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, tempRotation, anglespeed * Time.deltaTime);
            }
            else
            {
                tempRotation.z = -15;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, tempRotation, anglespeed * Time.deltaTime);
            }
            return;
        }
        
    }
}
