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
    public Monster monster;

    private void Awake()
    {
        monster = FindObjectOfType<Monster>();
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
        monster.targets.Remove(monster.targets[0]);
        Destroy(gameObject);
        
    }

    public override void Move()
    {
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
