using UnityEngine;

public class PlayerStats : Stats
{
    public System.Action onCure;

    public static PlayerStats instance;
    [Header("CriticalHit")]
    public Stat CriticalCal;
    public float criticalChance;
    [Header("Agility")]
    public Stat AgilityCal;
    public float Agility;
    override public void Start()
    {
        base.Start();
        instance = this;
        Agility = AgilityCal.getValue();
        criticalChance = CriticalCal.getValue();
    }

    public override void Damage(float originDamage)
    {
       
        float newDamage = originDamage - armor;
        if (newDamage > 0)
        {
            if (!evade())
            {
                CurrentHealth -= newDamage;
                BecomeInvisible();
                GetComponent<EntityFX>().FlashFX(PlayerStats.instance.InvicibleTime);
                onDamage();
            }
            else
            {
                Debug.Log("闪避成功");
            }
        }
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        Debug.Log(gameObject.name + "was hit " + newDamage);
    }

    private bool evade()
    {
        if (Random.Range(1, 101) < Agility)
        {
            return true;
        }
        return false;
    }

    

}
