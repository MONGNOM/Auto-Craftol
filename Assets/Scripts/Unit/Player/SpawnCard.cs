using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCard : MonoBehaviour
{
    public GameObject warrior;
    public List<GameObject> playerPos = new List<GameObject>(); // 배열로 수정
    public Transform pos;
    

  
    public void WarriorSpawn()
    {

        int range = Random.Range(0, 11);
        if (playerPos[range].GetComponentInChildren<Human>())
        {
            Instantiate(warrior, playerPos[range + 1].transform);
            Debug.Log("11");
        }
        else
            Instantiate(warrior, playerPos[range].transform);
    }   

    public void ArcherSpawn()
    {
        int range = Random.Range(0, 11);
        Instantiate(warrior, playerPos[range].transform);

    }
    public void PristSpawn()
    {
        int range = Random.Range(0, 11);
        Instantiate(warrior, playerPos[range].transform);

    }
}
