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
        /*if (collision.gameObject.layer == boss)){ //������ ������� �۵��� �ڵ�.
        }*/

    }
}