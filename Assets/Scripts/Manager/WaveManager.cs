using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
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
    
    public int random;


    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        for (int i = 0; i < mon.Length; i++)
        {
            monsters.Add(mon[i]);
            monsters[i] = mon[i];
        }
    }

    public void DeathPlayer()
    {
        for (int i = 0; i < humans.Count; i++)
        {   
            humans.Remove(humans[i]);
        }
    }

    public void FindPlayer()
    {
        Array.Clear(hum, 0, hum.Length);
       // Array.FindAll(hum,hum);
        humans.Clear();

        Debug.Log("player null");
        hum = FindObjectsOfType<Human>();
        for (int i = 0; i < hum.Length; i++)
        {
            humans.Add(hum[i]);
            humans[i] = hum[i];
            Debug.Log("player add");
        }
        random = UnityEngine.Random.Range(0, humans.Count);
    }

    public void FindUnit()
    {
        roundMonster = FindObjectOfType<Monster>();
    }

    public void UnitSpawn()
    {
        if (monsters.Count == 0)
        {
            mon = null;
            VictoryGame();
            return;
        }
            monsters[0].gameObject.SetActive(true);
            StartMove();
    }

    public void DestroyUnit()
    {
        monsters.Remove(monsters[0]);
    }

    public void Defeat()
    {
        if (hum == null)
        {
            Time.timeScale = 0;
        }
    }

    public void StartPos()
    {
        for (int i = 0; i < humans.Count; i++)
        {
            humans[i].transform.position = humans[i].startpos;
            humans[i].agent.speed = 0;
            humans[i].curhp = humans[i].Maxhp;
        }
    }

    public void StartMove()
    {
        if (humans != null)
        {
            for (int i = 0; i < humans.Count; i++)
            {
                humans[i].agent.speed = 1;
            }
        }
    }

    public void VictoryGame()
    {
        if(mon == null)
           Time.timeScale = 0;
    }


}
