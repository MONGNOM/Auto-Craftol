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
        listhuman[listhuman.Count].anim.SetFloat("SalshSpeed", 1);
        StopCoroutine(SpeedUpTime());

    }

    IEnumerator DamageUpTime()
    {
        float[] damage = new float[12];
        for (int i = 0; i < listhuman.Count; i++)
        {
            damage[i] = listhuman[i].damage;
            listhuman[i].damage *= 1.5f;
        }

        yield return new WaitForSeconds(damageTime);
        listhuman[listhuman.Count].damage *= damage[damage.Length]; // not backup?
        StopCoroutine(DamageUpTime());
    }
}
