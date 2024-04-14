using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    // private SpriteRenderer theSR;
    public ItemData data;
    // Start is called before the first frame update

    void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite=data.icon;
        gameObject.name=data.itemName;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>()!=null)  
        {
            Debug.Log(data.name+"is picked up!");
            Inventory.instance.AddItem(data);
            Destroy(gameObject);
        }
    }
}
