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
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        text.text = Mathf.Ceil(time).ToString(); 
    }
}
