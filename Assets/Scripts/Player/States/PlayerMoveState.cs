using UnityEngine;


public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(StateMachine stateMachine, Player player, string aniBoolName) : base(stateMachine, player, aniBoolName)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter move");
        player.ChangeAnimation("Move");
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.attack_1);
            player.theRB.velocity=new Vector2(0, player.theRB.velocity.y);
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.playerBlock);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            // stateMachine.ChangeState(player.dashStartState);
            SkillsManager.instance.dash.useSkill();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.theRB.velocity = new Vector2(-player.Speed, player.theRB.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.theRB.velocity = new Vector2(player.Speed, player.theRB.velocity.y);
        }

        
        //什么都不输入时,转为静止状态
        else
        {
            player.theRB.velocity = new Vector2(player.theRB.velocity.x, player.theRB.velocity.y);
            stateMachine.ChangeState(player.idleState);
        }
    }
    public override void Exit()
    {
        Debug.Log("end move");
    }
}