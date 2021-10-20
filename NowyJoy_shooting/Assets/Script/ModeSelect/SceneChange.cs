using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public GameObject storyMode;
    public GameObject storyMode_icon;
    public GameObject integrationMode;
    public GameObject integrationMode_icon;
    float checkTime = 0f;
    [SerializeField] [Range(1f, 5f)] float scaleSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mode_story"))
        {
            StartCoroutine(changing("story"));
        }
        else if (collision.CompareTag("Mode_integration"))
        {
            StartCoroutine(changing("integration"));
        }
    }

    public void ChangeSize(string selectedMode)
    {
        if (selectedMode=="story")
        {
            storyMode.transform.localScale = new Vector3(storyMode.transform.localScale.x + 2f * scaleSpeed * Time.deltaTime,
                storyMode.transform.localScale.y, 0);
            storyMode_icon.transform.localScale = new Vector3(storyMode_icon.transform.localScale.x + 1f * scaleSpeed * Time.deltaTime,
                storyMode_icon.transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);
            integrationMode.transform.localScale = new Vector3(integrationMode.transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
                integrationMode.transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
            integrationMode_icon.transform.localScale = new Vector3(integrationMode_icon.transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
                integrationMode_icon.transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
        }
        else if (selectedMode == "integration")
        {
            storyMode.transform.localScale = new Vector3(storyMode.transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
                storyMode.transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
            storyMode_icon.transform.localScale = new Vector3(storyMode_icon.transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
                storyMode_icon.transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
            integrationMode.transform.localScale = new Vector3(integrationMode.transform.localScale.x + 2f * scaleSpeed * Time.deltaTime,
                integrationMode.transform.localScale.y, 0);
            integrationMode_icon.transform.localScale = new Vector3(integrationMode_icon.transform.localScale.x + 1f * scaleSpeed * Time.deltaTime,
                integrationMode_icon.transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);
        }
    }

    IEnumerator changing(string mode)
    {
        while (checkTime <= 2.4f)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            checkTime += 0.1f;
            if (mode == "story")
            {
                ChangeSize("story");
            }
            else if (mode == "integration")
            {
                ChangeSize("integration");
            }
        }
        if (checkTime > 2.4f)
        {
            SceneManager.LoadScene("StageSelect");
            yield break;
        }
    }
}
