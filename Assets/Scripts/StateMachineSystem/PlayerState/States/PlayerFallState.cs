using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Fall", menuName = "ScriptableObject/PlayerState/Fall")]

public class PlayerFallState : PlayerState
{
    //[SerializeField] private AnimationCurve speedCurve;
    public override void Enter()
    {
        anim.Play("Fall");
        player.rb.gravityScale = 2.5f;
    }

    public override void LogicUpdate()
    {
        if (PlayerGroundCheck.Instance.isGround)
        {
            stateMachine.SwitchState(typeof(PlayerIdleState));
        }
    }

    public override void PhysicUpdate()
    {
        //speedCurve.Evaluate(StateDuration);
        player.Move(player.playerData.moveSpeed);
    }
}
