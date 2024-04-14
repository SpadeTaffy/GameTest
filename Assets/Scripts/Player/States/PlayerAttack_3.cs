using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack_3:PlayerState
{
    public PlayerAttack_3(StateMachine stateMachine, Player player, string aniBoolName):base(stateMachine,player,aniBoolName)
    {
    }

    
    public override void Enter()
    {
        Debug.Log("enter attack3");
        player.ChangeAnimation("Attack_3");
    }
    public override void Update()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("end attack3");
    }
}