using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{   
    public static Skeleton instance;
    [Header("Walk")]
    protected bool isFacingRight;

    public override void flipSprite()
    {
        
        if (theRB.velocity.x > 0.05f)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x < -0.05f)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }
            if(onFlipSprite!=null)
        {
            onFlipSprite();
        }
    }
    [Header("PlayerDetection")]
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private LayerMask WhatIsPlayer;
    [SerializeField] public RaycastHit2D RaycastToPlayer;

    [Header("Attack")]
     public bool isChasing;
    public float distanceOfAttack;
    public  bool hasAttacked;
    public GameObject player;
    [Header("stateMachine")]
    public  StateMachine stateMachine;
    public SkeletonWalkState walkState;
    public SkeletonAttackState attackState;
    public SkeletonStunState stunState;



    void Awake()
    {
        instance = this;
        stateMachine = new StateMachine();
        walkState = new SkeletonWalkState(stateMachine,this,"Walk");
        attackState = new SkeletonAttackState(stateMachine,this,"Attack");
        stunState = new SkeletonStunState(stateMachine,this,"Stun");
        closeAttackAlert();
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x+distanceToPlayer*transform.localScale.x,transform.position.y));
        
        
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(walkState);
        
    }

    // Update is called once per frame
    void Update()
    {   
        CheckAll();
        stateMachine.currentState.Update(); 
        // CurState=stateMachine.currentState.Name;
    }
    private void CheckAll()
    {
        WallCheck();
        GroundCheck();
        PlayerCheck();
    }
    private void PlayerCheck()
    {
        RaycastToPlayer = Physics2D.Raycast(transform.position,Vector2.right,distanceToPlayer*transform.localScale.x,WhatIsPlayer);
    }
}
