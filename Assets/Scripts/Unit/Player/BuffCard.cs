using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCard : MonoBehaviour
{
    Human human;
   
 
    private void Start()
    {
        human = FindObjectOfType<Human>();

    }
    public void AttackSpeedUp()
    {
        human.anim.SetFloat("SalshSpeed", 2);
    }

    public void Heal()
    {
        human.curhp += human.curhp *= 0.5f;
    }

    public void DamageUp()
    {
        human.damage *= 1.5f;
    }

    
}
