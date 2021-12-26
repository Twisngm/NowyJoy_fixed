using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float anglespeed;
    public Quaternion check;
    public void TransRotation(Quaternion tempRotation)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, tempRotation, anglespeed * Time.deltaTime);
    }
}
