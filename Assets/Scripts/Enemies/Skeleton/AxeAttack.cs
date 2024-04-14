using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonAxeAttack : MonoBehaviour
{
    public Transform skeletonSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("gonna hit player");

        if (Player.instance.stateMachine.currentState.Name == "Block")
        {
            Player.instance.blockSuccess = true;
        }
        else if(!PlayerStats.instance.isInvicible)
        {
            // other.GetComponent<EntityFX>().FlashFX(PlayerStats.instance.InvicibleTime);
            // PlayerStats.instance.BecomeInvisible();
            PlayerStats.instance.Damage(GetComponentInParent<EnemyStats>().attack);
            Player.instance.knockback(skeletonSprite.localScale.x);
        }

    }


}

