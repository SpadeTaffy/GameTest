using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack_1 : PlayerState
{
    public PlayerAttack_1(StateMachine stateMachine, Player player, string aniBoolName) : base(stateMachine, player, aniBoolName)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter attack1");
        player.ChangeAnimation("Attack_1");
    }
    public override void Update()
    {
        
        
            // if (Input.GetKeyDown(KeyCode.Mouse0))
            // {
            //     if (!player.cantAttack)
            //     {
            //         stateMachine.ChangeState(player.attack_2);
            //     }
            //     else
            //     {
            //         Debug.Log("cant attack");
            //     }
                
            // }
        
    }
    public override void Exit()
    {
        Debug.Log("end attack1");
    }
}