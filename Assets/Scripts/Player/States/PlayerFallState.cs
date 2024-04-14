using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFallState:PlayerState
{
    public PlayerFallState(StateMachine stateMachine, Player player, string aniBoolName):base(stateMachine,player,aniBoolName)
    {
    }

    
    public override void Enter()
    {
        Debug.Log("enter fall");
        player.ChangeAnimation("Fall");
    }
    public override void Update()
    {
        if(player.isAtGround)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    public override void Exit()
    {
        Debug.Log("end fall");
    }
}