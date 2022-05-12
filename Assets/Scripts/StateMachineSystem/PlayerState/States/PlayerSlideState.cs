using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Slide", menuName = "ScriptableObject/PlayerState/Slide")]
public class PlayerSlideState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.playerData.moveSpeed *= player.playerData.slideCoefficient;
        anim.Play("Slide");
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
    }

    public override void PhysicUpdate()
    {
        player.Move(player.playerData.moveSpeed);
    }
}
