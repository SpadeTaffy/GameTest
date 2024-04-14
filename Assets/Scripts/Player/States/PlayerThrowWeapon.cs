using UnityEngine;

public class PlayerThrowWeapon : PlayerState
{
    private float counter;
    public PlayerThrowWeapon(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter throw weapon state");
        player.ChangeAnimation(Name);
        counter=.5f;
        
    }
    public override void Update()
    {
        if(counter>0)
        {
            counter-=Time.deltaTime;
            if(counter<=0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
        
    }

    public override void Exit()
    {
        Debug.Log("exit throw weapon state");
    }
}