using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    float time;

    private void Awake()
    {
        time = 60f;
    }
    void Update()
    {
        time -= Time.deltaTime;

        if (time > 0)
        {

            if (time <= 10)
            {
                ColorChange();
            }

        }
        else
        {
            Time.timeScale = 0;
        }

        text.text = string.Format("{0}{1}", "Time left: ", Mathf.Ceil(time).ToString());

    }
    void ColorChange()
    {
        text.color = Color.red;
    }
}

