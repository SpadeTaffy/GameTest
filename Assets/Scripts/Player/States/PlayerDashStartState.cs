using UnityEngine;


public class PlayerDashStartState : PlayerState
{
    private float counter;
    public PlayerDashStartState(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter dash start");
        counter = .25f;
        player.ChangeAnimation(Name);
        PlayerStats.instance.BecomeInvisible(0.5f);
    }

    public override void Update()
    {
        if (counter > 0)
        {
            player.theRB.velocity = new Vector2(player.DashSpeed*player.transform.localScale.x,player.theRB.velocity.y);
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                player.stateMachine.ChangeState(player.dashStopState);
            }
        }

    }

    public override void Exit()
    {
        Debug.Log("exit dash start");
    }
}