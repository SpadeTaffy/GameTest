using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnce_Attack2 : StateMachineBehaviour
{
    private float counter;
    private float UnlockTime = 0.25f;
    private bool combo;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        combo=false;
        counter = stateInfo.length;
        Player.instance.combo=2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            // if(counter<=UnlockTime)
            // {
            //     Player.instance.cantAttack=false;
            // }
            // if(counter<=0)
            // {
            //     Player.instance.stateMachine.ChangeState(Player.instance.idleState);
            // }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (counter <= UnlockTime)
                {
                    combo=true;
                    Player.instance.stateMachine.ChangeState(Player.instance.attack_3);
                }
                else
                {
                    Debug.Log("cant attack");
                }

            }
            if (counter <= 0&&!combo)
            {
                Player.instance.stateMachine.ChangeState(Player.instance.idleState);
                Player.instance.combo=0;
            }
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
