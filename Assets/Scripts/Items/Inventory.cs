using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<InventoryItem> Equiped;
    public Dictionary<ItemData_equipment, InventoryItem> EquipedDic;
    public List<InventoryItem> Equipment;
    private Dictionary<ItemData, InventoryItem> EquipmentDic;

    public List<InventoryItem> Stash;
    private Dictionary<ItemData, InventoryItem> StashDic;
    public static Inventory instance;
    [Header("Inventory UI")]
    // public Transform EquipedParent;
    public Transform EquipmentParent;
    public Transform StashParent;
    // public UI_Itemslot[] Equipedslots;
    public UI_Itemslot Weaponslot;
    public UI_Itemslot Armorslot;
    public UI_Itemslot Amuletslot;

    public UI_Itemslot[] Equipmentslots;
    public UI_Itemslot[] Stashslots;
    void Awake()
    {
        instance = this;
        Equiped = new List<InventoryItem>();
        EquipedDic = new Dictionary<ItemData_equipment, InventoryItem>();
        Equipment = new List<InventoryItem>();
        EquipmentDic = new Dictionary<ItemData, InventoryItem>();
        Stash = new List<InventoryItem>();
        StashDic = new Dictionary<ItemData, InventoryItem>();
        // Equipedslots = EquipedParent.GetComponentInChildren<UI_Itemslot>();
        Equipmentslots = EquipmentParent.GetComponentsInChildren<UI_Itemslot>();
        Stashslots = StashParent.GetComponentsInChildren<UI_Itemslot>();
    }
    public void Equip(ItemData newdata)
    {
        ItemData_equipment newEquipmentData = newdata as ItemData_equipment;
        InventoryItem newEquipment = new InventoryItem(newEquipmentData);
        ItemData_equipment oldEquipmentData = null;
        // RemoveItem(data);
        foreach (KeyValuePair<ItemData_equipment, InventoryItem> item in EquipedDic)
        {
            if (item.Key.equipmentType == newEquipmentData.equipmentType)
            {
                oldEquipmentData = item.Key;
            }
        }
        if (oldEquipmentData != null)
        {
            if (EquipedDic.TryGetValue(oldEquipmentData, out InventoryItem value))
            {
                // Debug.Log("这里找已经装备的数组");
                Equiped.Remove(value);
                EquipedDic.Remove(oldEquipmentData);
                AddItem(oldEquipmentData);
            }
        }

        Equiped.Add(newEquipment);
        EquipedDic.Add(newEquipmentData, newEquipment);
        Debug.Log("应该移除" + newdata.itemName);
        RemoveItem(newdata);
    }

    public void Unequip(InventoryItem newitem)
    {
        // if(EquipmentDic.TryGetValue(newdata,out InventoryItem value))//如果在equipment中找到了
        // {
            // Debug.Log("脱下后进入内部");
            Equiped.Remove(newitem);
            EquipedDic.Remove((ItemData_equipment)newitem.data);
            AddItem(newitem.data);
        // }
    }
    public void AddItem(ItemData data)
    {
        if (data.itemType == ItemType.equipment)
        {
            if (EquipmentDic.TryGetValue(data, out InventoryItem value))//不会进入
            {
                value.AddStack();
            }
            else//执行这里
            {
                Debug.Log("新建");
                InventoryItem newEquipment = new InventoryItem(data);
                Equipment.Add(newEquipment);
                EquipmentDic.Add(data, newEquipment);
            }
        }
        else if (data.itemType == ItemType.material)
        {
            if (StashDic.TryGetValue(data, out InventoryItem value))
            {
                value.AddStack();
            }
            else
            {
                InventoryItem newItem = new InventoryItem(data);
                Stash.Add(newItem);
                StashDic.Add(data, newItem);
            }
        }

        UpdateSlotUI();
    }

    public void RemoveItem(ItemData data)
    {
        if (EquipmentDic.TryGetValue(data, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                Equipment.Remove(value);
                EquipmentDic.Remove(data);
            }
            else
            {
                value.RemoveStack();
            }
        }
        UpdateSlotUI();
    }
    private void UpdateSlotUI()
    {
        // for (int i = 0; i < Equipedslots.Length; i++)
        // {
        //     Equipedslots[i].CleanUpSlot();
        // }
        Weaponslot.CleanUpSlot();
        Armorslot.CleanUpSlot();
        Amuletslot.CleanUpSlot();

        for (int i = 0; i < Equipmentslots.Length; i++)
        {
            Equipmentslots[i].CleanUpSlot();
        }
        for (int i = 0; i < Stashslots.Length; i++)
        {
            Stashslots[i].CleanUpSlot();
        }
        // for (int i = 0; i < Equiped.Count; i++)
        // {
        //     Equipedslots[i].UpdateSlot(Equiped[i]);
        // }

        for(int i=0;i<Equiped.Count;i++)
        {
            ItemData_equipment EquipmentData=Equiped[i].data as ItemData_equipment;
            if(EquipmentData.equipmentType==EquipmentType.weapon)
            {
                Weaponslot.UpdateSlot(Equiped[i]);
            }
            else if(EquipmentData.equipmentType==EquipmentType.armor)
            {
                Armorslot.UpdateSlot(Equiped[i]);
            }
            else if(EquipmentData.equipmentType==EquipmentType.armor)
            {
                Amuletslot.UpdateSlot(Equiped[i]);
            }
        }
        for (int i = 0; i < Equipment.Count; i++)
        {
            Equipmentslots[i].UpdateSlot(Equipment[i]);
        }

        for (int i = 0; i < Stash.Count; i++)
        {
            Stashslots[i].UpdateSlot(Stash[i]);
        }
    }

}
