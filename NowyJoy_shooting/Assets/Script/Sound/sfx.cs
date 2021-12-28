using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfx : MonoBehaviour
{
    [SerializeField]
    private string click;
    [SerializeField]
    private string getcoin;

    public void coinSound()
    {
            SoundManager.Instance.PlaySE(getcoin);
    }

    public void clickSound()
    {
            SoundManager.Instance.PlaySE(click);
    }

    public void damagedSound()// �÷��̾� �ǰ���
    {
        SoundManager.Instance.PlaySE("damaged");
    }

    public void attackSound()// �÷��̾� ������
    {
        SoundManager.Instance.PlayattackSE("attack");
    }

    public void gameClearSound()// ���� Ŭ���� ����
    {
        SoundManager.Instance.PlaySE("gameClear");
    }

    public void explodeSound()// ź�� ������ �Ҹ�
    {
        SoundManager.Instance.PlaySE("explode");
    }

}
