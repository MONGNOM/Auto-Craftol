using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffCard : MonoBehaviour
{

    
    [SerializeField] float attackTime;
    [SerializeField] float damageTime;

    public Button buffButton;

    [SerializeField]
    private TextMeshProUGUI needCostText;

    [SerializeField]
    private int cost;



    public void AttackSpeedUp()
    {
        if (DataManager.instance.Coin == 0)
        {
            StartCoroutine(NeedCostText());
            return;
        }
        DataManager.instance.CostUse(cost);
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            if (!WaveManager.instance.humans[i].transform.GetChild(6).GetComponent<ParticleSystem>().isPlaying)
                WaveManager.instance.humans[i].transform.GetChild(6).GetComponent<ParticleSystem>().Play();
        }
            StartCoroutine(SpeedUpTime());
    }

    public void Heal()
    {
        if (DataManager.instance.Coin == 0)
        {
            StartCoroutine(NeedCostText());
            return;
        }

        DataManager.instance.CostUse(cost);
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            if (WaveManager.instance.humans[i].curhp + WaveManager.instance.humans[i].Maxhp > WaveManager.instance.humans[i].Maxhp)
                WaveManager.instance.humans[i].curhp = WaveManager.instance.humans[i].Maxhp;
            else
            {
                WaveManager.instance.humans[i].curhp += WaveManager.instance.humans[i].curhp *= 0.5f;
            }
                WaveManager.instance.humans[i].transform.GetChild(4).GetComponent<ParticleSystem>().Play();
        }
    }

    public void DamageUp()
    {
        if (DataManager.instance.Coin == 0)
        {
            StartCoroutine(NeedCostText());
            return;
        }
        DataManager.instance.CostUse(cost);
         for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
                WaveManager.instance.humans[i].transform.GetChild(5).GetComponent<ParticleSystem>().Play();
        }
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


    IEnumerator NeedCostText()
    {
        needCostText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        needCostText.gameObject.SetActive(false);
    }
}
