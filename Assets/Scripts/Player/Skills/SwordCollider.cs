using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsEnemy;
    public GameObject Sword;

    public Animator theAni;
    void Awake()
    {
        theAni=GetComponentInParent<Animator>();
        
    }

    public bool canPickUp = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (Physics2D.OverlapCircle(transform.position, 1f, whatIsPlayer) && canPickUp)
        {
            Debug.Log("剑碰到玩家了");
            Destroy(Sword);
            SkillsManager.instance.haveThrowSword=false;
        }
        else if (Physics2D.OverlapCircle(transform.position, 1f, whatIsEnemy))
        {
            Debug.Log("剑碰到敌人了");
            Sword.transform.parent = other.transform;
            Sword.GetComponent<Rigidbody2D>().isKinematic=true;
            // Sword.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
            theAni.CrossFade("Idle",0);
        }
        else if (Physics2D.OverlapCircle(transform.position, 1f, whatIsGround))
        {
            Debug.Log("剑碰到墙壁了");
            Sword.GetComponent<Rigidbody2D>().isKinematic=true;
            Sword.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezeAll;
            theAni.CrossFade("Idle",0);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, whatIsPlayer) && !canPickUp)
        {
            canPickUp=true;
            theAni.CrossFade("Spin",0);
            SkillsManager.instance.haveThrowSword=true;
        }
    }
}
