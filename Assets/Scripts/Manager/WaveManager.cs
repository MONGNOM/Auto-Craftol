using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public Transform spawnPosition;

    public Monster[] mon;
    public List<Monster> monsters = new List<Monster>();

    public Human[] hum;
    public List<Human> humans = new List<Human>(); 
    public Monster roundMonster;
    public Human roundHuman;
    private void Awake()
    {
        instance = this;
        
    }
    // humanfindTarget = RoundMonster;
    void Start()
    {
        for (int i = 0; i < mon.Length; i++)
        {
            monsters.Add(mon[i]);
            monsters[i] = mon[i];
        }
        UnitSpawn();
        FindUnit();
        FindPlayer();
    }


    public void FindPlayer()
    {
        hum = GameObject.FindObjectsOfType<Human>();
        roundHuman = FindObjectOfType<Human>();
        for (int i = 0; i < hum.Length; i++)
        {
            humans.Add(hum[i]);
            humans[i] = hum[i];
        }
    }

    public void FindUnit()
    {
        roundMonster = FindObjectOfType<Monster>();
    }

    public void UnitSpawn()
    {
        if (monsters.Count == 0)
        {
            VictoryGame();
            return;
        }
            monsters[0].gameObject.SetActive(true);
    }

    public void DestroyUnit()
    {
        monsters.Remove(monsters[0]);
    }

    public void VictoryGame()
    {
        if(roundMonster == null)
           Time.timeScale = 0;
    }
    
}
