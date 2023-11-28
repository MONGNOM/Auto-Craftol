using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : UnitBase
{
    [SerializeField, Range(0, 1000000)] private float hp;
    [Range(0, 1000)] public float damage;
    private NavMeshAgent agent;
    private Animator anim;
    private Human target;   
    private BoxCollider box;

    public Human[] humans; // GameManager --> stage clear --> humans[] clear; && Win or Lose
    public List<Human> targets = new List<Human>();

    private void Awake()
    {
        target  = FindObjectOfType<Human>();
        agent   = GetComponent<NavMeshAgent>();
        anim    = GetComponent<Animator>();
        box     = GetComponentInChildren<BoxCollider>();
    }

    private void Start()
    {   
        humans = GameObject.FindObjectsOfType<Human>();
        for (int i = 0; i < humans.Length; i++) 
        {
            targets.Add(target);
            targets[i] = humans[i]; // targets --> human != null but not find?
        }
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
        target.monsterTarget.Remove(target.monsterTarget[0]);
        anim.SetBool("Attack", false);
        Destroy(gameObject);
    }

    public override void Move()
    {
        humans = GameObject.FindObjectsOfType<Human>();
        for (int i = 0; i < humans.Length; i++)
        {
            targets[i] = humans[i]; // targets --> human != null but not find?
        }
        if (targets.Count == 0)
            Idle();
        else
        {
            transform.LookAt(targets[0].transform.position);
            agent.SetDestination(targets[0].transform.position);
            anim.SetBool("Idle", false);
        }
    }

    public void Idle()
    {
        anim.SetBool("Idle", true);
        humans = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
        else if (other.CompareTag("PlayerWeapon"))
        {
            Human human = other.gameObject.GetComponentInParent<Human>();
            hp -= human.damage;
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
