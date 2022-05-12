using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Dash", menuName = "ScriptableObject/PlayerState/Dash")]
public class PlayerDashState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.playerData.moveSpeed *= player.playerData.dashCoefficient;
        anim.Play("Dash");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (IsAnimationFinished)
        {
            Exit();
            stateMachine.SwitchState(typeof(PlayerIdleState));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpState));
        }
        if (input.IsAttack)
        {
            stateMachine.SwitchState(typeof(PlayerDashAttackState));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(player.playerData.moveSpeed);
    }
}
