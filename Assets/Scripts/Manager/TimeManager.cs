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
        breakTime = 5f;
    }

    private void Start()
    {
        breakTimeText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (WaveManager.instance.roundMonster == null)
        {
            BreakChangeTime();
            BreakTimeCount();
            if (breakTime <= 0)
            {
                roundTime = 60f;
                roundTimeText.color = Color.white;
                GameManager.instance.RoundStart();
                RoundChangeTime();
                RoundTimeCount();
                GameManager.instance.RoundStart();
                WaveManager.instance.FindUnit();
                WaveManager.instance.FindPlayer();
            }
        }

        if (roundTime > 0)
        {
            RoundTimeCount();
            if (roundTime <= 10)
            {
                ColorChange();
            }
        }
        else
        {
            if (WaveManager.instance.roundMonster != null)
                Time.timeScale = 0;

            BreakChangeTime();
            BreakTimeCount();
            if (breakTime <= 0)
            {
                roundTime = 60f;
                roundTimeText.color = Color.white;
                GameManager.instance.RoundStart();
                RoundChangeTime();
                RoundTimeCount();
                GameManager.instance.RoundStart();
                WaveManager.instance.FindUnit();
                WaveManager.instance.FindPlayer();
            }
        }
    }

    public void RoundTimeCount()
    {
        roundTime -= Time.deltaTime;
        roundTimeText.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(roundTime).ToString());
        breakTime = 10f;
    }

    public void BreakTimeCount()
    {
        breakTime -= Time.deltaTime;
        breakTimeText.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(breakTime).ToString());
        roundTime = 0f;
    }


    public void BreakChangeTime()
    {
        roundTimeText.gameObject.SetActive(false);
        breakTimeText.gameObject.SetActive(true);

    }

    public void RoundChangeTime()
    {
        roundTimeText.gameObject.SetActive(true);
        breakTimeText.gameObject.SetActive(false);

    }


    public void ColorChange()
    {
        roundTimeText.color = Color.red;
    }
}

