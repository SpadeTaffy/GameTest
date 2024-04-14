using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkeletonWalkState : SkeletonState
{
    public SkeletonWalkState(StateMachine stateMachine, Skeleton skeleton, string Name) : base(stateMachine, skeleton, Name)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter skeleton walk");
        skeleton.ChangeAnimation("Walk");
    }
    // public override void Update()
    // {
    //     Debug.Log("按下n键盘");
    //     // if(Input.GetKeyDown(KeyCode.N))
    //     {
    //         // Debug.Log("按下n键盘");
    //         // stateMachine.ChangeState(skeleton.attackState);
    //     }
    // }
    public override void Update()
    {

        if (skeleton.RaycastToPlayer)
        {
            Debug.Log("看到玩家");
            if (skeleton.RaycastToPlayer.distance > skeleton.distanceOfAttack)
            {
                Debug.Log("看到玩家,且准备快走");
                skeleton.isChasing = true;
            }
            else
            {
                Debug.Log("看到玩家,且准备攻击");
                stateMachine.ChangeState(skeleton.attackState);
                skeleton.isChasing = false;
            }
        }
        else
        {
            // Debug.Log("未看到玩家,正在巡逻");
            skeleton.isChasing = false;
            if (skeleton.isOnWall
                || !skeleton.isAtGround
            )
            {
                Debug.Log("撞到墙了,准备翻转");
                skeleton.flipSprite();
                Debug.Log(skeleton.transform.localScale.x);
                
            }
            skeleton.theRB.velocity = new Vector3(skeleton.transform.localScale.x * skeleton.Speed, skeleton.theRB.velocity.y);
        }
        if(skeleton.isChasing)
        {
            skeleton.theRB.velocity = new Vector3(skeleton.transform.localScale.x * skeleton.Speed*1.5f, skeleton.theRB.velocity.y);
        }
       
    }

    public override void Exit()
    {
        Debug.Log("end walk");
    }
}