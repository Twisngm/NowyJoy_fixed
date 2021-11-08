using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Turn();
    }
    private void collide(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletWall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Rabbit"){ //보스와 닿았을때 작동할 코드.
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

    }
}