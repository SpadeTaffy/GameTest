using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpState:PlayerState
{
    private bool hasChangedAnimation;
    public PlayerJumpState(StateMachine stateMachine, Player player, string aniBoolName):base(stateMachine,player,aniBoolName)
    {
    }

    
    public override void Enter()
    {
        Debug.Log("enter Jump");
        player.ChangeAnimation("Jump");
        player.theRB.velocity = new Vector3(player.theRB.velocity.x, player.JumpForce, 0f);
    }
    public override void Update()
    {
        if((player.theRB.velocity.y-0)<.05f)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }
    public override void Exit()
    {
        Debug.Log("end Jump");
    }
}