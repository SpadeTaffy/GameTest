using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SkeletonStunState : SkeletonState
{
    private float counter;
    public SkeletonStunState(StateMachine stateMachine, Skeleton skeleton, string Name) : base(stateMachine, skeleton, Name)
    {
    }
    public override void Enter()
    {
        counter=1f;
        skeleton.ChangeAnimation("Stun");
        skeleton.closeHitBox();
    }
    public override void Update()
    {
        if(counter>0)
        {
            counter-=Time.deltaTime;
            if(counter<=0)
            {
                stateMachine.ChangeState(skeleton.walkState);
            }
        }
    }

    public override void Exit()
    {
        // base.Exit();
    }
}
