using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject PBullet;
    public int bulletSpeed;
    CapsuleCollider2D collision;
    void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }
        /*if ((collision.gameObject.tag == boss) || (collision.gameObject.tag == wall)){
        }*/
        
    }

    // Update is called once per frame
    public void Attack()
    {
        GameObject Playerprefeb = Instantiate(PBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        gameObject.SetActive(true);
        collision = GetComponent<CapsuleCollider2D>();
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)-gameObject.transform.position);
        GetComponent<Transform>().transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime);
    }
}
