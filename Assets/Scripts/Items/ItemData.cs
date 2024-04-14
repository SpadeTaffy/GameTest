using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType{material,equipment};
[CreateAssetMenu(fileName ="newItemData",menuName ="Data/Item")]
public class ItemData : ScriptableObject
{
    
    public string itemName;
    public Sprite icon;
    public ItemType itemType; 
}
