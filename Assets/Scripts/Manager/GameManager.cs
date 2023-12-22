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
        TimeManager.instance.RoundTime();

    }

    public void RoundEnd()
    {
        TimeManager.instance.BreakTime();

    }
}
