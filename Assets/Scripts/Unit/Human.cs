using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : UnitBase
{
    [SerializeField, Range(0, 1000)] private float hp;
    [SerializeField, Range(0, 1000)] private float damage;
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        transform.LookAt(target.transform.position);

        if (hp <= 0)
            Death();
        else
            Move();
    }
    public virtual void DistanceAttack()
    {
        anim.SetBool("Attack",true);
        
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
        //find monster;
        
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Attack();
        }
        else if (other.CompareTag("MonsterWeapon"))
        {
            Monster monster = other.gameObject.GetComponentInParent<Monster>();
            hp -= monster.damage;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            anim.SetBool("Attack", false);
        }
    }
}
