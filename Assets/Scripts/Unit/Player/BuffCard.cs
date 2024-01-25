using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCard : MonoBehaviour
{
   
    [SerializeField] float attackTime;
    [SerializeField] float damageTime;
   

    

    public void AttackSpeedUp()
    {
        StartCoroutine(SpeedUpTime());
    }

    public void Heal()
    {
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].curhp += WaveManager.instance.humans[i].curhp *= 0.5f;
        }
    }

    public void DamageUp()
    {
        StartCoroutine(DamageUpTime());
    }

    IEnumerator SpeedUpTime()
    {
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].anim.SetFloat("SalshSpeed", 2);
        }

        yield return new WaitForSeconds(attackTime);

        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].anim.SetFloat("SalshSpeed", 1);
        }
        StopCoroutine(SpeedUpTime());
    }

    IEnumerator DamageUpTime()
    {
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].damage *= 1.2f;
        }

        yield return new WaitForSeconds(damageTime);

        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].damage *= 0.85f;
        }
        StopCoroutine(DamageUpTime());
    }
}
