using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Run", menuName = "ScriptableObject/PlayerState/Run")]
public class PlayerRunState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Run");
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerIdleState));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerJumpState));
        }
        if (input.IsAttack)
        {
            stateMachine.SwitchState(typeof(PlayerAttackState));
        }
        if (input.IsDash)
        {
            stateMachine.SwitchState(typeof(PlayerDashState));
        }
        if (input.IsSlide)
        {
            stateMachine.SwitchState(typeof(PlayerSlideState));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(player.playerData.moveSpeed);
    }
}
