using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public static Player instance;
    [Header("stateMachine")]
    public StateMachine stateMachine;

    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerFallState fallState;

    public PlayerAttack_1 attack_1;
    public PlayerAttack_2 attack_2;
    public PlayerAttack_3 attack_3;

    public PlayerBlock playerBlock;
    public PlayerCounterStrike counterStrike;

    public PlayerDashStartState dashStartState;
    public PlayerDashStopState dashStopState;

    public PlayerAiming aiming;
    public PlayerThrowWeapon throwWeapon;
    [Header("NumberProperty")]
    public float JumpForce;

    public float DashSpeed;

    public int combo;
    [Header("BoolProperty")]
    public bool blockSuccess;
    public bool moveRight;

    



    void Awake()
    {

        instance = this;
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        fallState = new PlayerFallState(stateMachine, this, "Fall");
        attack_1 = new PlayerAttack_1(stateMachine, this, "Attack_1");
        attack_2 = new PlayerAttack_2(stateMachine, this, "Attack_2");
        attack_3 = new PlayerAttack_3(stateMachine, this, "Attack_3");
        playerBlock = new PlayerBlock(stateMachine, this, "Block");
        counterStrike = new PlayerCounterStrike(stateMachine, this, "CounterStrike");
        dashStartState = new PlayerDashStartState(stateMachine, this, "Dash_start");
        dashStopState = new PlayerDashStopState(stateMachine, this, "Dash_stop");
        aiming = new PlayerAiming(stateMachine,this,"Aiming");
        throwWeapon = new PlayerThrowWeapon(stateMachine,this,"ThrowWeapon");

    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        
    }


    void Update()
    {
        CheckGroundAndWall();
        stateMachine.currentState.Update();//检测是否按键切换了状态
        flipSprite();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        base.OnDrawGizmos();
    }
    protected virtual void flipSprite()
    {

        if (theRB.velocity.x > 0.05f && Input.GetKey(KeyCode.D))
        {

            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (theRB.velocity.x < -0.05f && Input.GetKey(KeyCode.A))
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Debug.Log("不停翻转");
        if(onFlipSprite!=null)
        {
            onFlipSprite();
        }
            
    }

    public void CheckGroundAndWall()
    {
        WallCheck();
        GroundCheck();
    }

    

}
