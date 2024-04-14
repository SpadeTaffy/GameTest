using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    public override void Update()
    {
        base.Update();
    }

    public override void useSkill()
    {
        if(cooldownCounter<=0)
        {
            Debug.Log("使用技能");
            Player.instance.stateMachine.ChangeState(Player.instance.dashStartState);
            cooldownCounter=cooldownTime;
            SkillsManager.instance.mirage.useSkill();
        }
        else
        {
            Debug.Log("技能冷却中");
        }
    }
}
