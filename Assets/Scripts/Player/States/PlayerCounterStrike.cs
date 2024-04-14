using UnityEngine;

public class PlayerCounterStrike : PlayerState
{
    private float counter;
    public PlayerCounterStrike(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter counterstrike");
        player.ChangeAnimation("CounterStrike");
        counter = 1;
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
            // if(Input.GetKeyDown(KeyCode.N))
            // {
            //     stateMachine.ChangeState(player.idleState);
            // }
        }
    }

    public override void Exit()
    {
        Debug.Log("exit counterstrike");
        player.blockSuccess=false;
    }
}