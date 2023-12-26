using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public Transform spawnPosition;

    public List<Monster> monsters = new List<Monster>();

    void Start()
    {
        
    }

    public void UnitSpawn()
    {
        Instantiate(monsters[0], spawnPosition);
    }

    public void DestroyUnit()
    {
        monsters.Remove(monsters[0]);
    }
    
}
