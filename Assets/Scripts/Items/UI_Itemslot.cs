
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Itemslot : MonoBehaviour,IPointerDownHandler
{
// public Image itemImage;
public TextMeshProUGUI itemText;
public InventoryItem item;

    public virtual void OnPointerDown(PointerEventData eventData){}

    public virtual void OnValidate()
    {
       itemText=GetComponentInChildren<TextMeshProUGUI>();
    }

    public virtual void CleanUpSlot()
    {
        item = null;
        GetComponent<Image>().sprite=null;
        itemText.text = "";
    }
    public virtual void UpdateSlot(InventoryItem item)
    {
        this.item=item;
        //  if(item!=null)
        // {
            GetComponent<Image>().sprite = item.data.icon;
            if(item.stackSize>0)
            {
                itemText.text=item.stackSize.ToString();
            }
            else
            {
                itemText.text="";
            }
        // }
    }

}
