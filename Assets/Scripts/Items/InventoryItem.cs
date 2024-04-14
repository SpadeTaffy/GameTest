using System;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    public ItemData data;
    public int stackSize;

    public InventoryItem(ItemData data)
    {
        this.data=data;
        Debug.Log(data.itemName+" stackSize之前为"+stackSize);
        AddStack();
        Debug.Log(data.itemName+" stackSize之后为"+stackSize);
    }

    public void AddStack()=>stackSize++;
    public void RemoveStack()=>stackSize--;
}