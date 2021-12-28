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
        TxT[0] = "1. 드래그하여 이동할 수 있습니다.";
        TxT[1] = "2. 탄막에 맞으면 HP가 줄어듭니다.";
        TxT[2] = "3. 시간이 모두 소모되면 클리어 됩니다.";
        TxT[3] = "4. 공격을 보스에게 맞출 시 시간이 감소합니다.";
        TxT[4] = "5. 남은 체력 80% 이상 클리어 시, 퍼펙트 클리어를 달성합니다.";


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
