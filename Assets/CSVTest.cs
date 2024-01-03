using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVTest : MonoBehaviour
{
    List<string> mon = new List<string>();
    public new string name;
    public int hp;
    public int damage;

    private void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Stat");

        try
        {
            name = (string)data[0]["Name"];
            hp = (int)data[0]["Hp"];
            damage = (int)data[0]["Damage"];

            for (int i = 0; i < data.Count; i++)
            {
                mon.Add((string)data[i]["Name"]);
                Debug.Log(mon[i]);
            }
        }
        catch
        {
            Debug.Log("Fail");
        }
    }
}
