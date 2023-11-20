using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : UnitBase
{
    [SerializeField, Range(0, 1000)] private float hp;
    [Range(0, 1000)] public float damage;
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject target;
    private BoxCollider box;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        box = GetComponentInChildren<BoxCollider>();
    }
    private void Update()
    {
        if (hp <= 0)
            Death();
        else
            Move();
    }
    public virtual void DistanceAttack()
    {
        anim.SetBool("Attack", true);
    }

    public override void Attack()
    {
        DistanceAttack();
    }

    public override void Death()
    {
        anim.SetBool("Death", true);
        agent.isStopped = true;
    }

    public override void Move()
    {
        //find Player;
        transform.LookAt(target.transform.position);
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
        }
    }

    public void OnWeapon()
    {
        box.enabled = true;
    }

    public void OffWeapon()
    {
        box.enabled = false;
    }

}
