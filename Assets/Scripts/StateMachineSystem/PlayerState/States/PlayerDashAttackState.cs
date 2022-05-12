using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_DashAttack", menuName = "ScriptableObject/PlayerState/DashAttack")]
public class PlayerDashAttackState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        anim.Play("DashAttack");
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            Exit();
            stateMachine.SwitchState(typeof(PlayerIdleState));
        }
    }
}
