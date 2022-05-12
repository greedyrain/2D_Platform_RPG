using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家所有状态的父类；
/// </summary>
public abstract class PlayerState : ScriptableObject, IState
{
    protected Animator anim;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput input;
    protected PlayerController player;
    protected bool IsAnimationFinished => StateDuration >= anim.GetCurrentAnimatorStateInfo(0).length;
    protected float StateDuration => Time.time - startTime;
    protected float startTime;


    public void Initialize(Animator anim, PlayerStateMachine stateMachine, PlayerInput input, PlayerController player)
    {
        this.anim = anim;
        this.stateMachine = stateMachine;
        this.input = input;
        this.player = player;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
    }

    public virtual void Exit() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicUpdate() { }
}
