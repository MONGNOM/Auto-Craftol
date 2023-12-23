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
        roundTime = 15f;
        breakTime = 10f;
    }
    void Update()
    {
        RoundTimeCount();

        if (roundTime > 0)
        {
            if (roundTime <= 10)
            {
                ColorChange();
            }
        }
        else
        {
            ChangeTime();
            BreakTimeCount();
        }
    }

    public void RoundTimeCount()
    {
        roundTime -= Time.deltaTime;
        roundTimeText.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(roundTime).ToString());
    }

    public void BreakTimeCount()
    {
        breakTime -= Time.deltaTime;
        breakTimeText.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(breakTime).ToString());
    }


    public void ChangeTime()
    {
        roundTimeText.gameObject.SetActive(false);
        breakTimeText.gameObject.SetActive(true);
    }



    public void ColorChange()
    {
        roundTimeText.color = Color.red;
    }
}

