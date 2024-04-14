using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSwordThrow : MonoBehaviour
{
    public Rigidbody2D theRB;
    public CircleCollider2D theCollider;
    
    // public Animator theAni;
    void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        theCollider = GetComponent<CircleCollider2D>();
        // theAni = GetComponent<Animator>();
    }

    public void setSwordProperty(Vector2 direction, float gravity,float ThrowForce)
    {
        theRB.velocity = direction*ThrowForce;
        theRB.gravityScale = gravity;
    }


}
