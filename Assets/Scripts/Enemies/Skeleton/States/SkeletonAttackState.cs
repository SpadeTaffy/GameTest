using UnityEngine;
public class SkeletonAttackState:SkeletonState
{
    private float attackCounter;

    
    public SkeletonAttackState(StateMachine stateMachine, Skeleton skeleton, string Name) : base(stateMachine, skeleton, Name)
    {
    }


    public override void Enter()
    {   
        attackCounter=2f;
        Debug.Log("enter attack");
        skeleton.ChangeAnimation("Attack");
        Skeleton.instance.hasAttacked=false;
        skeleton.theRB.velocity=new Vector3(0,skeleton.theRB.velocity.y);
    }
    public override void Update()
    {   
        if(attackCounter>0)
        {
            attackCounter-=Time.deltaTime;
            if(attackCounter<=0)
            {
                Debug.Log("has attacked");
                stateMachine.ChangeState(skeleton.walkState);
            }
        }
        // if(Skeleton.instance.hasAttacked)
        // {
        //     stateMachine.ChangeState(skeleton.walkState);
        // }
        // else
        // {
        //     if(skeleton.RaycastToPlayer.distance>2)
        //     {
        //         if(!hasAttacked)
        //         {
        //             skeleton.theRB.velocity=new Vector3(skeleton.Speed*skeleton.transform.localScale.x,skeleton.theRB.velocity.y);
        //         }
        //     }
        // }
    }
    public override void Exit()
    {
        Debug.Log("end attack");
    }
}