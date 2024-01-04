using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        List<Dictionary<string, object>> monsterdata = CSVReader.Read("MonsterStat");
        for (int i = 0; i < monsterdata.Count; i++)
        {
            WaveManager.instance.mon[i].name = (string)monsterdata[i]["Name"];
            WaveManager.instance.mon[i].maxhp = (int)monsterdata[i]["Hp"];
            WaveManager.instance.mon[i].damage = (int)monsterdata[i]["Damage"];
        }
    }

    
}
