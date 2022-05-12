using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Idle", menuName = "ScriptableObject/PlayerState/Idle")]
public class PlayerIdleState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Idle");
        player.SetVelocityX(0f);
        player.rb.gravityScale = 2;
        player.playerData.moveSpeed = player.playerData.originalMoveSpeed;
    }

    public override void LogicUpdate()
    {
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerRunState));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpState));
        }
        if (input.IsAttack)
        {
            stateMachine.SwitchState(typeof(PlayerAttackState));
        }
        //if (input.IsDash)
        //{
        //    stateMachine.SwitchState(typeof(PlayerDashState));
        //}
    }
}
