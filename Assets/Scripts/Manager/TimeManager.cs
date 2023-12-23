using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public TextMeshProUGUI roundTimeText;
    public TextMeshProUGUI breakTimeText;
    public float roundTime;
    public float breakTime;

    private void Awake()
    {
        instance = this;
        roundTime = 60f;
        breakTime = 10f;
    }
    void Update()
    {
        TimeCount();

        if (roundTime > 0)
        {
            if (roundTime <= 10)
            {
                ColorChange();
            }
        }
        else
            TimeStop();
    }

    public void TimeCount()
    {
        roundTime -= Time.deltaTime;
        roundTimeText.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(roundTime).ToString());
    }

    public void TimeStart()
    {
        Time.timeScale = 1;
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void ColorChange()
    {
        roundTimeText.color = Color.red;
    }
}

