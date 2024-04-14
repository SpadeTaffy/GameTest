using UnityEngine;


public class PlayerDashStopState : PlayerState
{
    private float counter;
    public PlayerDashStopState(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter dash stop");
        player.ChangeAnimation(Name);
        counter=.25f;
    }

    public override void Update()
    {
        if(counter>0)
        {
            player.theRB.velocity = new Vector2(player.DashSpeed*player.transform.localScale.x,player.theRB.velocity.y);
            counter-=Time.deltaTime;
            if(counter<=0)
            {
                player.stateMachine.ChangeState(player.idleState);
            }   
        }
    }

    public override void Exit()
    {
        Debug.Log("exit dash stop");
    }
}