using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PristHeal : MonoBehaviour
{
    Human player;
    public ParticleSystem particle;
    private void Awake()
    {
        player = GetComponentInParent<Human>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Human>())
        {
            particle = other.GetComponentInChildren<ParticleSystem>();
            Human human = other.GetComponent<Human>();
            particle.Play();

            if (human.curhp + player.damage > human.Maxhp)
            {
                human.curhp = human.Maxhp;
            }
            else
            {
                Debug.Log("111");
                human.curhp += player.damage;
            }
        }

    }
}
