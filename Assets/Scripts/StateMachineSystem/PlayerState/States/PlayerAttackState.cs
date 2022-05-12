using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Attack", menuName = "ScriptableObject/PlayerState/Attack")]
public class PlayerAttackState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.rb.velocity = Vector2.zero;
        anim.Play("Attack");
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerIdleState));
        }
    }
}
