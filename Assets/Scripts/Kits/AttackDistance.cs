using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistance : MonoBehaviour
{
    //  public GameObject AttackCheckPoint;
     public float distanceOfAttack=3;
     protected virtual void OnDrawGizmos()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x+distanceOfAttack,transform.position.y));
    }
}
