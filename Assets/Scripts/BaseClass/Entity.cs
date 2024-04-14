using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public System.Action onFlipSprite;
    [SerializeField] public Rigidbody2D theRB;
    [SerializeField] public Animator theAni;
    [Header("GroundInfo")]

    public GameObject GroundCheckPoint;
    [SerializeField] protected float distanceToGround;
    [SerializeField] public bool isAtGround;
    [SerializeField] protected LayerMask WhatIsGround;
    [Header("WallInfo")]
    [SerializeField] protected float distanceToWall;
    [SerializeField] public bool isOnWall;
    [SerializeField] protected LayerMask WhatIsWall;

    [Header("MoveInfo")]
    [SerializeField] public float Speed;

    public Vector2 knockbackDirection;
    public bool knockedback;
    [Header("FX")]
    public EntityFX entityFX;
    [Header("GameObject")]
    public GameObject hitbox;



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheckPoint.transform.position, new Vector3(GroundCheckPoint.transform.position.x, GroundCheckPoint.transform.position.y - distanceToGround));
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x+distanceToWall*transform.localScale.x,transform.position.y));
        // Gizmos.DrawLine(AttackCheckPoint.position,new Vector3(AttackCheckPoint.position.x+distanceOfAttack*transform.localScale.x,AttackCheckPoint.position.y));
    }
    protected virtual void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        theAni = GetComponent<Animator>();
        entityFX = GetComponent<EntityFX>();
        closeHitBox();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected virtual void GroundCheck()
    {
        isAtGround = Physics2D.Raycast(GroundCheckPoint.transform.position, Vector2.down, distanceToGround, WhatIsGround);
    }
    protected virtual void WallCheck()
    {
        isOnWall = Physics2D.Raycast(transform.position, Vector2.right, distanceToWall*transform.localScale.x,WhatIsWall);
    }
    

    public virtual void flipSprite()
    {
        
        
    
        
    }

    public void ChangeAnimation(string animationName,float crossfadeTime=0.2f)
    {
        theAni.CrossFade(animationName,crossfadeTime);
    }

    public void knockback(float direction)
    {
        StartCoroutine(knockbackCo(direction));
    }
    public virtual IEnumerator knockbackCo(float direction)
    {
        Debug.Log("get knocked back");
        knockedback=true;
        theRB.velocity = new Vector2(knockbackDirection.x*direction,knockbackDirection.y);
        yield return new WaitForSeconds(0.5f);
        knockedback=false;
    }

    public void openHitBox()
    {
        Debug.Log("应该打开攻击");
        hitbox.SetActive(true);
    }

    public void closeHitBox()
    {
        Debug.Log("应该关闭攻击");
        hitbox.SetActive(false);
    }
}
