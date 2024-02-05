using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WaveManager.instance.humans[WaveManager.instance.random].curhp -= animator.GetComponent<Monster>().damage;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
