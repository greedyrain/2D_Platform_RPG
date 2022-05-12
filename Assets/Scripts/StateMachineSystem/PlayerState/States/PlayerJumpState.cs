using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerState_Jump", menuName = "ScriptableObject/PlayerState/Jump")]
public class PlayerJumpState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Jump");
        player.SetVelocityY(player.playerData.jumpForce);
    }

    public override void PhysicUpdate()
    {
        if (player.isFalling)
        {
            stateMachine.SwitchState(typeof(PlayerFallState));
        }
        player.Move(player.playerData.moveSpeed);
    }
}
