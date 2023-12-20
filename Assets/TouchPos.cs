using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPos : MonoBehaviour, IPointerClickHandler
{
    public SpawnCard spawn;
    public GameObject warrior;
    public GameObject archer;
    public GameObject prist;

    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        if (spawn.warrior)
        {
            Instantiate(warrior, gameObject.transform);
            spawn.warrior = false;

        }
        else if (spawn.archer)
        {
            Instantiate(archer, gameObject.transform);
            spawn.archer = false;
        }
        else if (spawn.prist)
        {
            Instantiate(prist, gameObject.transform);
            spawn.prist = false;
            Debug.Log("11");
        }
    }
}
