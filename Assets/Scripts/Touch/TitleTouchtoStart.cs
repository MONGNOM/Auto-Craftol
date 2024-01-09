using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleTouchtoStart : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        StartCoroutine(TextBlink());
    }

    void Update()
    {
        
    }

    IEnumerator TextBlink()
    {
        while (true)
        {
            text.text = "Touch to Start";
            yield return new WaitForSeconds(0.5f);
            text.text = "";
            yield return new WaitForSeconds(0.5f);

        }
    }
}
