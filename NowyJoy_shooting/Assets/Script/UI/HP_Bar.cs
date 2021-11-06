using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public Image HP;
    public float hp;
    GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    private void Start()
    {
        gm = GameManager.GM_Instance;
        hp = gm.HP;
    }

    // Update is called once per frame
    void Update()
    {     
        HP.fillAmount = gm.HP / hp;
    }
}
