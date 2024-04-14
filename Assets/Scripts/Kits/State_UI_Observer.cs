using UnityEngine;
using UnityEngine.UI;

public class State_UI_Observer:MonoBehaviour
{
    public static State_UI_Observer instance;
    public Slider theSlider;
    // public Entity entity;
    public Stats stats;
    void Awake()
    {
        instance=this;
    }
    void Start()
    {
        theSlider = GetComponentInChildren<Slider>();
        // entity = GetComponentInParent<Entity>();
        // entity.onFlipSprite+=flipUI;
        stats=GetComponentInParent<Stats>();
        stats.onDamage+=UpdateHealthUI;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        theSlider.maxValue=stats.MaxHealth.getValue();
        theSlider.value = stats.CurrentHealth;
    }

}