using UnityEngine;
 public enum EquipmentType{weapon,armor,amulet}
[CreateAssetMenu(fileName ="newEquipmentData",menuName ="Data/Equipment")]
public class ItemData_equipment:ItemData
{
   
    public EquipmentType equipmentType;
}