    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Human : UnitBase
{
    [SerializeField, Range(0, 100000)]  private float Maxhp;
    [Range(0, 1000000)]                 public  float damage;
    [HideInInspector]                   public  Monster monster;
    /*[HideInInspector]*/               public float curhp;
                                        private NavMeshAgent agent;
                                        private BoxCollider box;    
                                        public Animator anim;
                                        public  Monster[] monsters;
                                        public  List<Monster> monsterTarget = new List<Monster>();
                                        public Image hpbar;
    public float findTime = 0f;
    

    private void Awake()
    {
       
        box     = GetComponentInChildren<BoxCollider>();
        agent   = GetComponent<NavMeshAgent>();
        anim    = GetComponentInChildren<Animator>();
       

    }

    private void Start()    
    {
        monster = FindObjectOfType<Monster>();
        monsters = FindObjectsOfType<Monster>();
        curhp = Maxhp;
        box.enabled = false;
        
    }
    private void Update()
    {
        findTime += Time.deltaTime;

        if (findTime >= 10.1)
            FindTarget();

        hpbar.fillAmount = curhp / Maxhp;
        if (curhp <= 0)
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
        Destroy(gameObject);
        
    }

    public void FindTarget()
    {
        // round start --> fix
        monsters = FindObjectsOfType<Monster>();
        findTime = 0;
        Debug.Log("유닛 찾음ㅋ");
    }

    public override void Move()
    {
        if (monsters[0] != null)
        {
            anim.SetBool("Idle", false);
            agent.SetDestination(monsters[0].transform.position);
            transform.LookAt(monsters[0].transform.position);
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Monster"))
        {
            Attack();
        }
        else if (other.CompareTag("MonsterWeapon"))
        {
            // Umm hp collider cap and Attackcol ?
             Monster monster = other.gameObject.GetComponentInParent<Monster>();
            curhp -= monster.damage;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            anim.SetBool("Attack", false);
        }
    }

    public void OnPlayerWeapon()
    {
        box.enabled = true;
    }

    public void OffPlayerWeapon()
    {
        box.enabled = false;
    }
}
