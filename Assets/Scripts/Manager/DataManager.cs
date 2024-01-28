using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public TextMeshProUGUI costText;
    public TextMeshProUGUI countText;

    
    public delegate void Cost(int value);
    public static event Cost UseCost;


    private int cost;
    // use cost --> buffcard --> delegate --> cost -= value -->
    public int count;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cost = 10;

        List<Dictionary<string, object>> monsterdata = CSVReader.Read("MonsterStat");
        for (int i = 0; i < monsterdata.Count; i++)
        {
            WaveManager.instance.mon[i].name = (string)monsterdata[i]["Name"];
            WaveManager.instance.mon[i].maxhp = (int)monsterdata[i]["Hp"];
            WaveManager.instance.mon[i].damage = (int)monsterdata[i]["Damage"];
        }

        WaveManager.HumanCount += CostText;
        WaveManager.HumanCount += CountText;
        UseCost = CostUse;

    }

    void CostUse(int value)
    {
        cost -= value;
    }

    void CostText()
    {
        costText.text = cost.ToString();
    }

    void CountText()
    {
        countText.text = WaveManager.instance.humans.Count.ToString();
        if (WaveManager.instance.humans.Count >= 12)
        {
            countText.color = Color.red;
        }
    }

}
