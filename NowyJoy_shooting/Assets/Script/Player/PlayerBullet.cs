using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject PBullet;
    public int bulletSpeed;
    CapsuleCollider2D collision;
    private void Update()
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }
        /*if (collision.gameObject.layer == boss)){ //보스와 닿았을때 작동할 코드.
        }*/
        
    }
    public void Move(Vector2 dir, float PBspeed)
    {
        gameObject.transform.Translate(dir.normalized * PBspeed * Time.deltaTime);
    }
}