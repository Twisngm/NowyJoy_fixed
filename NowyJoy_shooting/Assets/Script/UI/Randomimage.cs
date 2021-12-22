using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomimage : MonoBehaviour
{
    Image image;
    public Sprite background1;
    public Sprite background1h;
    public Sprite background2;
    public Sprite background3;
    public Sprite background3h;
    public Sprite background4;
    public Sprite background5;
    public Sprite background5h;
    public Sprite background6;
    public Sprite white;

    void Start()
    {
        image = GetComponent<Image>();
        int groundnum = 0;
        groundnum = random();
        if (groundnum == 1)
        {
            image.sprite = background1;
        }
        else if (groundnum == 2)
        {
            image.sprite = background1h;
        }
        else if (groundnum == 3)
        {
            image.sprite = background2;
        }
        else if (groundnum == 4)
        {
            image.sprite = background3;
        }
        else if (groundnum == 5)
        {
            image.sprite = background3h;
        }
        else if (groundnum == 6)
        {
            image.sprite = background4;
        }
        else if (groundnum == 7)
        {
            image.sprite = background5;
        }
        else if (groundnum == 8)
        {
            image.sprite = background5h;
        }
        else if (groundnum == 9)
        {
            image.sprite = background6;
        }
        else
        {
            image.sprite = white;
        }
    }

    int random()
    {
        int num = 0;
        num = Random.Range(1, 10);
        return num;
    }
}
