using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    GameManager gm;
    public SpriteRenderer sprRend;
    Animator anim;
    public bool safeZone;
    public GameManager GM;
    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        anim = GetComponentInParent<Animator>();
        GM = GameManager.GM_Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("safeZone"))
        {
            safeZone = true;
        }
        if (collision.CompareTag("Enemy") || collision.CompareTag("Rabbit") || collision.tag == "Owl")
        {
            OnDamaged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("safeZone"))
        {
            safeZone = false;
        }
    }

    public void OnDamaged()
    {
        if (safeZone)
        {
            return;
        }
        else if (GM.Perfectmode == true && GM.HP <= GM.MaxHP * 0.8f)
        {
            return;
        }
        gm.HP--;
        gameObject.layer = 7;
        transform.parent.gameObject.layer = 7;
        anim.SetTrigger("Hit");
        //  sprRend.color = new Color(1, 1, 1, 0.4f);
        SoundManager.Instance.PlaySE("damaged"); // 플레이어 피격음
        Invoke("OffDamaged", 1.5f);
    }

    void OffDamaged()
    {
        gameObject.layer = 6;
        transform.parent.gameObject.layer = 6;

     //   sprRend.color = new Color(1, 1, 1, 1);
    }
}
