using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Monster monster;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        monster = FindObjectOfType<Monster>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (monster == null) // next stage;
        {
            TimeManager.instance.BreakTime();
        }
    }
}
