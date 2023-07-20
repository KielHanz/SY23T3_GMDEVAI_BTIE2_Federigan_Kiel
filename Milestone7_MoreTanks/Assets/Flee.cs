using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Flee : NPCBaseFSM
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var direction = NPC.transform.position - opponent.transform.position;
        direction.y = 0;

        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction - new Vector3(opponent.transform.position.x, 0, opponent.transform.position.y)), rotSpeed * Time.deltaTime);

        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
