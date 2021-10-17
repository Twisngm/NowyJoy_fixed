using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stage;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (stage)
            {
                case "1":
                    Debug.Log("1 스테이지로 이동합니다.");
                    //SceneManager.LoadScene("stage1");
                    break;
                case "1-1":
                    Debug.Log("1-1 스테이지로 이동합니다.");
                    break;
                case "2":
                    Debug.Log("2 스테이지로 이동합니다.");
                    break;
            }
        }
    }
}
