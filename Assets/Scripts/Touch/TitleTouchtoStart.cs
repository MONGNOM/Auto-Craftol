using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class TitleTouchtoStart : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI text;
   
    void Start()
    {
        StartCoroutine(TextBlink());
    }

   
    IEnumerator TextBlink()
    {
        while (true)
        {
            text.text = "Touch to Start";
            yield return new WaitForSeconds(0.6f);
            text.text = "";
            yield return new WaitForSeconds(0.6f);

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("11");
        SceneManager.LoadScene("MapScene");
        Debug.Log("22");
    }
}
