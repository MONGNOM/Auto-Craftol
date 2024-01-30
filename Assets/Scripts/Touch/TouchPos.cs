using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPos : MonoBehaviour, IPointerClickHandler
{
    public SpawnCard spawn;
    public GameObject warrior;
    public GameObject archer;
    public GameObject prist;
    public TextMeshProUGUI textMeshProUGUI;
    public bool posUnit;
    public Human human;


    private void Start()
    {
        textMeshProUGUI.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        if (spawn.warrior)
        {
            if (gameObject.transform.GetComponentInChildren<Human>())
            {
                StartCoroutine(unitexsits());
                return;
            }
            else
            {
                Instantiate(warrior, gameObject.transform);
                spawn.warrior = false;
            }

        }
        else if (spawn.archer)
        {
            if (gameObject.transform.GetComponentInChildren<Human>())
            {
                StartCoroutine(unitexsits());
                return;
            }
            else
            {
                Instantiate(archer, gameObject.transform);
                spawn.archer = false;
            }
        }
        else if (spawn.prist)
        {
            if (gameObject.transform.GetComponentInChildren<Human>())
            {
                StartCoroutine(unitexsits());
                return;
            }
            else
            {
                Instantiate(prist, gameObject.transform);
                spawn.prist = false;
            }
        }


    }

    IEnumerator unitexsits()
    {
        textMeshProUGUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        textMeshProUGUI.gameObject.SetActive(false);

    }
}
