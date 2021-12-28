using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text Text;
    public string[] TxT = new string[5];
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        TxT[0] = "1. �巡���Ͽ� �̵��� �� �ֽ��ϴ�.";
        TxT[1] = "2. ź���� ������ HP�� �پ��ϴ�.";
        TxT[2] = "3. �ð��� ��� �Ҹ�Ǹ� Ŭ���� �˴ϴ�.";
        TxT[3] = "4. ������ �������� ���� �� �ð��� �����մϴ�.";
        TxT[4] = "5. ���� ü�� 80% �̻� Ŭ���� ��, ����Ʈ Ŭ��� �޼��մϴ�.";


        Invoke("NextText", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        TextBox();   
    }

    void TextBox()
    {
        Text.text = TxT[index];
    }

    void NextText()
    {
        if (index < 4)
        {
            index++;
            Invoke("NextText", 10f);
        }
    }
}
