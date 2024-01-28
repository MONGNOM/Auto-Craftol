using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffCard : MonoBehaviour
{
   
    [SerializeField] float attackTime;
    [SerializeField] float damageTime;

    public Button buffButton;

    [SerializeField]
    private int cost;



    public void AttackSpeedUp()
    {
        if (DataManager.instance.Coin == 0)
            return;

            DataManager.instance.CostUse(cost);
            StartCoroutine(SpeedUpTime());
    }

    public void Heal()
    {
        if (DataManager.instance.Coin == 0)
            return;

            DataManager.instance.CostUse(cost);
            for (int i = 0; i < WaveManager.instance.humans.Count; i++)
            {
                WaveManager.instance.humans[i].curhp += WaveManager.instance.humans[i].curhp *= 0.5f;
            }
    }

    public void DamageUp()
    {
        if (DataManager.instance.Coin == 0)
            return;

            DataManager.instance.CostUse(cost);
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
