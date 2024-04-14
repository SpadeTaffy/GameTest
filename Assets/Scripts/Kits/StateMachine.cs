using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StateMachine 
{
    public  State currentState;
    public void Initialize(State currentState)
    {
        this.currentState=currentState;
        currentState.Enter();
    }
    public void ChangeState(State newState)
    {
        currentState.Exit();
        this.currentState=newState;
        currentState.Enter();
    }
}
