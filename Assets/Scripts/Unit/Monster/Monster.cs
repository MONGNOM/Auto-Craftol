using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public new string name;
    [SerializeField, Range(0, 1000000)] public float maxhp;
    [SerializeField]                    private float curhp;
    [Range(0, 1000)]                    public float damage;
    private NavMeshAgent agent;
    private Animator anim;
    public Image hpbar;
    public List<Human> targets = new List<Human>();



    private void Awake()
    {
        agent   = GetComponent<NavMeshAgent>();
        anim    = GetComponent<Animator>();
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

    public  void Death()
    {
        anim.SetBool("Death", true);
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        WaveManager.instance.DestroyUnit();
        TimeManager.instance.ChoiceSpawnCard();
        WaveManager.instance.StartPos();
        DataManager.instance.Coin = 10;
        Destroy(gameObject);
    }

    public  void Move()
    {
        if (WaveManager.instance.humans.Count == 0)
            Idle();
        else
        {  
            transform.LookAt(WaveManager.instance.humans[WaveManager.instance.random].transform.position);
            agent.destination = Vector3.zero;
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
        if (other.CompareTag("PlayerWeapon"))
        {
            Human human = other.gameObject.GetComponentInParent<Human>();
            curhp -= human.damage;
        }

    }

  
}
