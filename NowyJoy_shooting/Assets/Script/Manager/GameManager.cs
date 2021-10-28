using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HP;
    public int stagenum;
    public GameObject ptnManager;


    void Start()
    {
        ptnManager.SetActive(true);
       
    }

}
