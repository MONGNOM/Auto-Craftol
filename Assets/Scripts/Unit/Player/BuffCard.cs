using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCard : MonoBehaviour
{
    public List<Human> listhuman = new List<Human>();
    public Human[] humans;
    Human human;
   

    
    private void Start()
    {
        human = FindObjectOfType<Human>();
        humans = FindObjectsOfType<Human>();
        for (int i = 0; i < humans.Length; i++)
        {
            listhuman.Add(human);
            listhuman[i] = humans[i];
        }
    }
    public void AttackSpeedUp()
    {
        for (int i = 0; i < listhuman.Count; i++)
        {
             listhuman[i].anim.SetFloat("SalshSpeed", 2);
        }
    }

    public void Heal()
    {
        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].curhp += listhuman[i].curhp *= 0.5f;
        }
    }

    public void DamageUp()
    {
        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].damage *= 1.5f;
        }
    }

    
}
