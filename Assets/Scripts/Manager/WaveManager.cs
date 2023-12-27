using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public Transform spawnPosition;

    public GameObject monster;
    public Monster[] mon;
    public List<Monster> monsters = new List<Monster>();

    void Start()
    {
        monster.SetActive(true);
        mon = GameObject.FindObjectsOfType<Monster>();
        for (int i = 0; i < mon.Length; i++)
        {
            monsters.Add(mon[i]);
            monsters[i] = mon[i];
        }
    }


    public void UnitSpawn()
    {
        monsters[0].gameObject.SetActive(true);
    }

    public void DestroyUnit()
    {
        monsters.Remove(monsters[0]);
    }
    
}
