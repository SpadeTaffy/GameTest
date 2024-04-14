using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    
    override public void Start()
    {
        base.Start();

    }
    public override void Damage(float originDamage)
    {
         if(critical())
        {
            originDamage=originDamage*2;
            Debug.Log("暴击!");
        }
        float newDamage=originDamage-GetComponent<EnemyStats>().armor;
        if(newDamage>0)
        {
            CurrentHealth -= newDamage;
            onDamage();
        }
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        Debug.Log( gameObject.name+"was hit " + newDamage);
    }
    private bool critical()
    {
        if (Random.Range(1, 101) < PlayerStats.instance.criticalChance)
        {
            return true;
        }
        return false;
    }
}
