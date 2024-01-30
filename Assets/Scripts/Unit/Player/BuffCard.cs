using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffCard : MonoBehaviour
{

    public ParticleSystem particle;
    [SerializeField] float attackTime;
    [SerializeField] float damageTime;

    public Button buffButton;

    [SerializeField]
    private TextMeshProUGUI needCostText;

    [SerializeField]
    private int cost;

    private void Start()
    {
        needCostText.gameObject.SetActive(false);
    }

    public void AttackSpeedUp()
    {
        if (DataManager.instance.Coin == 0)
        {
            StartCoroutine(NeedCostText());
            return;
        }
        DataManager.instance.CostUse(cost);
        particle = FindObjectOfType<Human>().transform.GetChild(6).GetComponent<ParticleSystem>();
        if (!particle.isPlaying)
            particle.Play();
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
        particle = FindObjectOfType<Human>().transform.GetChild(4).GetComponent<ParticleSystem>();
        particle.Play();
        for (int i = 0; i < WaveManager.instance.humans.Count; i++)
        {
            WaveManager.instance.humans[i].curhp += WaveManager.instance.humans[i].curhp *= 0.5f;
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
        particle = FindObjectOfType<Human>().transform.GetChild(5).GetComponent<ParticleSystem>();
        particle.Play();
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
