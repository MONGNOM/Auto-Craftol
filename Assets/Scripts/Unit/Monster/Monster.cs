using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : UnitBase
{
    public new string name;
    [SerializeField, Range(0, 1000000)] public float maxhp;
    [SerializeField]                    private float curhp;
    [Range(0, 1000)]                    public float damage;
    private NavMeshAgent agent;
    private Animator anim;
    private BoxCollider box;
    public Image hpbar;
    public List<Human> targets = new List<Human>();
    



    private void Awake()
    {
        agent   = GetComponent<NavMeshAgent>();
        anim    = GetComponent<Animator>();
        box     = GetComponentInChildren<BoxCollider>();
    }

    private void Start()
    {
        curhp = maxhp;
    }
    private void Update()
    {
        hpbar.fillAmount = curhp / maxhp;
        if (curhp <= 0)
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
        anim.SetBool("Attack", false);
        WaveManager.instance.DestroyUnit();
        TimeManager.instance.ChoiceSpawnCard();
        WaveManager.instance.StartPos();

        Destroy(gameObject);
    }

    public override void Move()
    {
        if (WaveManager.instance.humans.Count == 0)
            Idle();
        else
        {  // find player tag , colider
           
            transform.LookAt(WaveManager.instance.humans[WaveManager.instance.random].transform.position);
            agent.SetDestination(WaveManager.instance.humans[WaveManager.instance.random].transform.position);
            anim.SetBool("Idle", false);
        }
    }

    public void Idle()
    {   
        anim.SetBool("Idle", true);
        WaveManager.instance.hum = null;
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
            curhp -= human.damage;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
            Debug.Log("player가 없다 공격중지");
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
