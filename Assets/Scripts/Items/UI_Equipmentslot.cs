using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Equipments:UI_Itemslot
{

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(item.data.itemType==ItemType.equipment)
        {
            Debug.Log("穿上"+item.data.itemName);
            Inventory.instance.Equip(item.data);
        }
    }
}