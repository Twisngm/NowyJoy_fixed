using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CutScene_3 : MonoBehaviour
{
    public RectTransform firstCut;
    public GameObject Button;
    public GameObject[] Scenes;
    public int index = 0;
    void Start()
    {
        firstCut.DOScale(new Vector3(1, 1, 1), 1f);
        Invoke("SetButton", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextCut()
    {

        if (index < Scenes.Length)
        {

            Scenes[index].SetActive(true);
            index++;
        }
        else
            SceneManager.LoadScene("Title");

    }

    void SetButton()
    {
        Button.SetActive(false);
    }
}
