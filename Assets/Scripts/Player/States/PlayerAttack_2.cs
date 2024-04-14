using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack_2 : PlayerState
{
    public PlayerAttack_2(StateMachine stateMachine, Player player, string aniBoolName) : base(stateMachine, player, aniBoolName)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter attack2");
        player.ChangeAnimation("Attack_2");
    }
    public override void Update()
    {
        // if (!player.cantAttack)
        // {
        //     if (Input.GetKeyDown(KeyCode.Mouse0))
        //     {
        //         stateMachine.ChangeState(player.attack_3);
        //     }
        // }

    }
    public override void Exit()
    {
        Debug.Log("end attack2");
    }
}