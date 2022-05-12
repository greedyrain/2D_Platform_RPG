using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1.持有所有的状态类，并对状态进行管理和切换
/// 2.负责进行当前状态的更新；
/// </summary>
public class StateMachine : MonoBehaviour
{
    private IState currentState;
    public Dictionary<System.Type,IState> stateDic;
    private void Update()
    {
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateDic[newStateType]);
    }
}
