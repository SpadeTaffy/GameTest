using UnityEngine;

public class PlayerBlock : PlayerState
{
    private float counter;
    public PlayerBlock(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter block");
        player.ChangeAnimation("Block");
        counter = .5f;
        player.theRB.velocity=new Vector2(0,player.theRB.velocity.y);
    }
    public override void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
            if (player.blockSuccess)
            {
                stateMachine.ChangeState(player.counterStrike);
            }
        }

    }

    public override void Exit()
    {
        Debug.Log("exit block");
    }
}