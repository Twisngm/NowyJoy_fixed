using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRotater : MonoBehaviour
{
    public GameObject Player;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation.z = -(Player.transform.rotation.z);
        transform.rotation = rotation;
    }
}
