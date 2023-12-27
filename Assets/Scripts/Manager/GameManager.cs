using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }


    public void RoundStart()
    {
        WaveManager.instance.UnitSpawn();
    }
    public void RoundEnd()
    {
        WaveManager.instance.monsters[0].gameObject.SetActive(false);
    }

}
