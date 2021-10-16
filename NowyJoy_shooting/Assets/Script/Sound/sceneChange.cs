using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void ChangeToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ChangeToModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }
}
