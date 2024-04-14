using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdleState:PlayerState
{
    public PlayerIdleState(StateMachine stateMachine, Player player, string Name):base(stateMachine,player,Name)
    {
    }

    
    public override void Enter()
    {
        Debug.Log("enter idle");
        player.ChangeAnimation("Idle");
    }
    public override void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.attack_1);
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.playerBlock);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            // stateMachine.ChangeState(player.dashStartState);
            SkillsManager.instance.dash.useSkill();
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(player.aiming);
        }
        else if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            player.moveRight=false;
            stateMachine.ChangeState(player.moveState);
        }
        //什么都不输入时,转为静止状态
        else
        {
            if(!Player.instance.knockedback)
            {
                player.theRB.velocity = new Vector2(0, player.theRB.velocity.y);
            }
            
        }
    }
    public override void Exit()
    {
        Debug.Log("end idle");
    }
}