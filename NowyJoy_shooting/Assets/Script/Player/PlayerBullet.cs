using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector3 roller;
    public int rollangle;
    public float rollspeed;
    ObjectManager obj;
    private void Awake()
    {
        obj = GameObject.Find("Managers").transform.GetChild(1).GetComponent<ObjectManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        roller.z = 0;
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Turn();
        }
    }
    private void collide(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletWall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Rabbit" || collision.gameObject.tag == "Bird" || collision.gameObject.tag == "Owl")
        { //보스와 닿았을때 작동할 코드.
            Destroy(gameObject);

        }

    }
    public void Launch(Vector2 Dir, float Speed)
    {
        //rigidbody2D.AddForce(Dir * Speed, ForceMode2D.Impulse);
        rigidbody2D.AddForce(Vector2.up * Speed, ForceMode2D.Impulse);
    }
    void Turn()
    {
        roller.z += rollangle;

        transform.Rotate(roller);

        SoundManager.Instance.PlayattackSE("attack"); //플레이어 공격 소리
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletWall")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss_Heart")
        { //보스와 닿았을때 작동할 코드.
            GameObject bulletFire = obj.MakeObj("bulletFire");
            GameObject MinusTime = obj.MakeObj("minusTime");
            bulletFire.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            SoundManager.Instance.PlaySE("explode"); // 보스에게 맞을때 사운드 - 임시로
            // Destroy(gameObject);

        }
    }
}