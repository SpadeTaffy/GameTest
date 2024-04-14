using System.Collections;
using UnityEngine;

public class PlayerController : Entity
{
    public static PlayerController instance;
    [Header("Move")]
    public float MoveSpeed;


    [Header("Dash")]
    public float DashSpeed;
    public float DashTime;
    [SerializeField] private float dashCounter;
    [SerializeField] private bool isDashing;


    [Header("Jump")]
    public float JumpForce;
    public float WallJumpForce;

    [SerializeField] private bool canDoubleJump;
    [SerializeField] private bool canWallJump;
    // [SerializeField] private bool isAtGround;

    [SerializeField] private bool isWallJumping;

    [Header("Attack")]
    [SerializeField] private int combo;
    public float ComboTime;
    [SerializeField] private float comboCounter;

    [SerializeField] private bool isAttacking;

    // [Header("SelfProperty")]
    // [SerializeField] private Rigidbody2D theRB;
    // private Animator theAni;

    public float speed;
    
    void Start()
    {
        instance = this;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        speed = theRB.velocity.x;
        //检测处于哪个状态
        MapDetect();
        //用于判断运动
        MoveFunction();
    }
    #region Utility
    private void CountDown()
    {
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                isDashing = false;
            }
        }
        if (comboCounter > 0)
        {
            comboCounter -= Time.deltaTime;
            if (comboCounter <= 0)
            {
                combo = 0;
                theAni.SetInteger("Combo", 0);
            }
        }


    }

    private void MapDetect()
    {
        // isAtGround = Physics2D.OverlapCircle(GroundDetect.transform.position, .005f, WhatIsGround);
        // isAtGround = Physics2D.Raycast(transform.position, Vector2.down, distanceTOGround, WhatIsGround);
        GroundCheck();
        WallCheck();
        /*用于检测是否在地面*/
        if (isAtGround)
        {
            if (theAni.GetBool("AtGround") != true)
            {
                theAni.SetBool("AtGround", true);
            }
            if (isWallJumping)
            {
                // Debug.Log("guan");
                isWallJumping = false;
            }

        }
        else if (!isAtGround)
        {
            if (theAni.GetBool("AtGround") != false)
            {
                theAni.SetBool("AtGround", false);
            }
        }
        /*用于检测是否在地面*/
        /*用于检测是否在墙体*/
        if (isOnWall)
        {

            canWallJump = true;
            if (theAni.GetBool("OnWall") != true)
            {
                theAni.SetBool("OnWall", true);
            }
            if (isWallJumping)
            {
                isWallJumping = false;
            }

        }
        else if (!isOnWall)
        {
            if (theAni.GetBool("OnWall") != false)
            {
                theAni.SetBool("OnWall", false);
            }
        }
        /*用于检测是否在地面*/

    }

    private void MoveFunction()
    {
        CountDown();
        if (!isWallJumping && !isDashing && !isAttacking)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dash();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }

            if (Input.GetKey(KeyCode.A))
            {
                theRB.velocity = new Vector2(-MoveSpeed, theRB.velocity.y);
                theAni.SetBool("IsMoving", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                theRB.velocity = new Vector2(MoveSpeed, theRB.velocity.y);
                theAni.SetBool("IsMoving", true);
            }
            else
            {
                // Debug.Log("走到停止步骤");
                theAni.SetBool("IsMoving", false);
                theRB.velocity = new Vector2(0, theRB.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (!isAtGround)
                {
                    if (isOnWall)
                    {

                        if (canWallJump)
                        {
                            // Debug.Log(2);
                            walljump();
                        }
                    }

                    else if (canDoubleJump)
                    {
                        // Debug.Log(2);
                        canDoubleJump = false;
                        doublejump();
                    }
                }
                else if (isAtGround)
                {
                    canDoubleJump = true;
                    // Debug.Log(3);
                    jump();
                }

            }
            flipSprite();
        }
        else if (isDashing)
        {
            theRB.velocity = new Vector2(DashSpeed * transform.localScale.x, theRB.velocity.y);
        }
        else if (isAttacking)
        {
            theRB.velocity = new Vector2(0, 0);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }
    }



    #endregion

    #region Actions
    private void jump()
    {
        theRB.velocity = new Vector3(theRB.velocity.x, JumpForce, 0f);
        // theAni.SetTrigger("Jump");
    }

    private void doublejump()
    {
        theRB.velocity = new Vector3(theRB.velocity.x, JumpForce, 0f);
    }

    private void walljump()
    {

        isWallJumping = true;
        canWallJump = false;
        theRB.velocity = new Vector3(-transform.localScale.x * WallJumpForce, JumpForce, 0f);
    }

    private void dash()
    {
        if (!isAttacking)
        {
            dashCounter = DashTime / 2;
            isDashing = true;
            theAni.SetTrigger("IsDashing");
        }

    }
    #endregion

    #region Attack
    private void Attack()
    {
        isAttacking = true;
        comboCounter = ComboTime;
        if (theAni.GetBool("IsAttacking") != true)
        {
            theAni.SetBool("IsAttacking", true);
        }
        theAni.SetInteger("Combo", combo);
        combo++;
        if (combo == 3)
        {
            combo = 0;
        }
    }

    public void changeIsAttacking()
    {
        StartCoroutine(changeIsAttackingCo());
    }

    private IEnumerator changeIsAttackingCo()
    {
        yield return new WaitForSeconds(0.8f);
        isAttacking = false;
    }
    #endregion



}
