using System.Collections;
using UnityEngine;

public class Stats:MonoBehaviour
{
    public System.Action onDamage;
    [Header("Health")]
    public Stat MaxHealth;
    public float CurrentHealth;
    [Header("Attack")]
    public Stat AttackCal;
    public float attack;
    [Header("Armor")]
    public Stat ArmorCal;
    public float armor;
    
    [Header("Invicible")]

    public float InvicibleTime;
    public bool isInvicible;

    public virtual void Start()
    {
        
        CurrentHealth = MaxHealth.getValue();
        // CurrentHealth=50;
        attack = AttackCal.getValue();
        armor = ArmorCal.getValue();
    } 

       public virtual void Damage(float originDamage)
    {
        // float newDamage=originDamage-PlayerStats.instance.armor;
        // if(newDamage>0)
        // {
        //     CurrentHealth -= newDamage;
        // }
        // if (CurrentHealth <= 0)
        // {
        //     gameObject.SetActive(false);
        // }
        // Debug.Log( gameObject.name+"was hit " + newDamage);
    }
    public void BecomeInvisible(float time=1f)
    {
        StartCoroutine(InvicibleCo(time));
    }
    private IEnumerator InvicibleCo(float time = 1f)
    {
            isInvicible = true;
            yield return new WaitForSeconds(time);
            isInvicible = false;
    }
}