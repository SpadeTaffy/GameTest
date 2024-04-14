using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    public Transform PlayerSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponentInParent<EntityFX>().FlashFX();
        other.GetComponentInParent<Skeleton>().stateMachine.ChangeState(Skeleton.instance.stunState);
        other.GetComponentInParent<EnemyStats>().Damage(PlayerStats.instance.attack);
        if(Player.instance.combo==3)
        {
            other.GetComponentInParent<Entity>().knockback(PlayerSprite.localScale.x);
        }
        
    }

   
}
