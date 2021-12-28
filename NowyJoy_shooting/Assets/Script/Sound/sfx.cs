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

    public void damagedSound()// 플레이어 피격음
    {
        SoundManager.Instance.PlaySE("damaged");
    }

    public void attackSound()// 플레이어 공격음
    {
        SoundManager.Instance.PlayattackSE("attack");
    }

    public void gameClearSound()// 게임 클리어 음악
    {
        SoundManager.Instance.PlaySE("gameClear");
    }

    public void explodeSound()// 탄막 터질때 소리
    {
        SoundManager.Instance.PlaySE("explode");
    }

}
