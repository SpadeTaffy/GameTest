using UnityEngine;

public class PlayerAiming : PlayerState
{
    public PlayerAiming(StateMachine stateMachine, Player player, string Name) : base(stateMachine, player, Name)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter aiming");
        player.ChangeAnimation(Name);

    }
    public override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1)&& !SkillsManager.instance.haveThrowSword)
        {
            SkillsManager.instance.throwSword.setDotsActive(true);
        }
        else if (Input.GetKey(KeyCode.Mouse1) && !SkillsManager.instance.haveThrowSword)
        {

            SkillsManager.instance.throwSword.getThrowDirection();
            for (int i = 0; i < SkillsManager.instance.throwSword.numberOfDots; i++)
            {
                SkillsManager.instance.throwSword.dots[i].transform.position = SkillsManager.instance.throwSword.setDotsPosition(SkillsManager.instance.throwSword.IntervalTime * i);
            }

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1)&& !SkillsManager.instance.haveThrowSword)
        {
            SkillsManager.instance.throwSword.setDotsActive(false);
            SkillsManager.instance.throwSword.useSkill();
            stateMachine.ChangeState(player.throwWeapon);
        }

    }

    public override void Exit()
    {
        Debug.Log("exit aiming");

    }
}