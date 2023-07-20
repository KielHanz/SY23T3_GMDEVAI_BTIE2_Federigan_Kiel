using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<TankAI>().StartFiring();
    }

    override public void OnStateUpdate(Animator animtor, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.transform.LookAt(opponent.transform.position);
    }

    override public void OnStateExit(Animator animtor, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<TankAI>().StopFiring();
    }
}