using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCard : MonoBehaviour
{
    public List<Human> listhuman = new List<Human>();
    public Human[] humans;
    [SerializeField] float attackTime;
    [SerializeField] float damageTime;
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
        StartCoroutine(SpeedUpTime());
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
        StartCoroutine(DamageUpTime());
    }

    IEnumerator SpeedUpTime()
    {
        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].anim.SetFloat("SalshSpeed", 2);
        }

        yield return new WaitForSeconds(attackTime);

        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].anim.SetFloat("SalshSpeed", 1);
        }
        StopCoroutine(SpeedUpTime());

    }

    IEnumerator DamageUpTime()
    {
        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].damage *= 1.2f;
        }

        yield return new WaitForSeconds(damageTime);

        for (int i = 0; i < listhuman.Count; i++)
        {
            listhuman[i].damage *= 0.85f;
        }
        StopCoroutine(DamageUpTime());
    }
}
