using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Equipedslot:UI_Itemslot
{

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(item.data.itemType==ItemType.equipment)
        {
            Debug.Log("脱下"+item.data.itemName);
            Inventory.instance.Unequip(item);
        }
    }
}