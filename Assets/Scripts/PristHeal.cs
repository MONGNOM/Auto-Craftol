using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PristHeal : MonoBehaviour
{
    Human player;
    private void Awake()
    {
        player = GetComponentInParent<Human>();
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Human>())    
        {
            Human human = other.GetComponent<Human>();
            human.curhp += player.damage;
        }           
    }
}
