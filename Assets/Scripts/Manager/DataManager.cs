using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI countText;

    public event UnityAction<int> OnchageCoin;

    [SerializeField]
    private int coin;


    public int Coin         { get { return coin; }
                              set { coin = value; OnchageCoin?.Invoke(coin); } }
    
    public int count;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        OnchageCoin += CoinText;
        List<Dictionary<string, object>> monsterdata = CSVReader.Read("MonsterStat");
        for (int i = 0; i < monsterdata.Count; i++)
        {
            WaveManager.instance.mon[i].name = (string)monsterdata[i]["Name"];
            WaveManager.instance.mon[i].maxhp = (int)monsterdata[i]["Hp"];
            WaveManager.instance.mon[i].damage = (int)monsterdata[i]["Damage"];
        }
        WaveManager.HumanCount += CountText;
        CoinText(coin);
    }

    public void CostUse(int value)
    { 
        Coin -= value;
    }

    void CoinText(int coin)
    {
        coinText.text = coin.ToString();
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
