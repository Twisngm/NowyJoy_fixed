using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class CutScene_2 : MonoBehaviour
{
    public RectTransform firstCut;
    public RectTransform[] MoveCut;
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
        else if (index == 3)
        {
            MoveCut[0].DOAnchorPos(new Vector3(0, 0, 0), 1.5f);
            index++;
        }
        else if (index == 4)
        {
            MoveCut[1].DOAnchorPos(new Vector3(0, 0, 0), 1.5f);
            index++;
        }
        else
            SceneManager.LoadScene("stage8");
    }

    void SetButton()
    {
        Button.SetActive(false);
    }
}
