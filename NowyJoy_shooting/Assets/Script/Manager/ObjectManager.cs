using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameManager GM;

    GameObject[] bulletA;
    GameObject[] bulletB;
    GameObject[] bulletC;
    GameObject[] playerClone;

    public GameObject bulletA_Prefabs;

    public GameObject bulletB_Prefabs;

    public GameObject bulletC_Prefabs;



    public GameObject player_Prefabs;

    GameObject[] targetPool;

    private void Awake()
    {
        bulletA = new GameObject[20];
        bulletB = new GameObject[150];
        bulletC = new GameObject[70];
        playerClone = new GameObject[1];
        Generate();

    }

   




    void Generate()
    {
        for(int index=0; index < bulletA.Length; index++)
        {
            bulletA[index] = Instantiate(bulletA_Prefabs);
            bulletA[index].SetActive(false);

        }

        for (int index = 0; index < bulletB.Length; index++)
        {
            bulletB[index] = Instantiate(bulletB_Prefabs);
            bulletB[index].SetActive(false);
        }

        for (int index = 0; index < bulletC.Length; index++)
        {
            bulletC[index] = Instantiate(bulletC_Prefabs);
            bulletC[index].SetActive(false);
        }
        playerClone[0] = Instantiate(player_Prefabs);
        playerClone[0].SetActive(false);
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "bulletA":
                targetPool = bulletA;
                break;

            case "bulletB":
                targetPool = bulletB;
                break;

            case "bulletC":
                targetPool = bulletC;
                break;

            case "playerClone":
                targetPool = playerClone;
                break;
        }


        for (int index = 0; index < targetPool.Length; index++)
        {
               if (!targetPool[index].activeSelf)
               {
                        targetPool[index].SetActive(true);
                        return targetPool[index];
               }
        }
        return null;
        
    }
}
