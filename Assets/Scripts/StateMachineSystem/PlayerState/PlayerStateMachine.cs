using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator anim;
    [SerializeField] PlayerState[] states;
    PlayerInput input;
    PlayerController player;

    private void Awake()
    {
        stateDic = new Dictionary<System.Type, IState>(states.Length);
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();
        foreach (var state in states)
        {
            state.Initialize(anim, this,input,player);
            stateDic.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        SwitchOn(stateDic[typeof(PlayerIdleState)]);//游戏开始时进入Idle状态；
    }
}
