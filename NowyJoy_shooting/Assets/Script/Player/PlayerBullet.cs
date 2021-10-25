using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
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
}