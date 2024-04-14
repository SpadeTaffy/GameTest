using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EquipmentBag;
    public GameObject StashBag;
    public bool openBag;

    public int cureTime=3;
    public float cureAmount=20; 
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddEventListener("PressH", showBag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            EventManager.Instance.EventTrigger("PressH");
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            
            if(cureTime>0)
            {
                PlayerStats.instance.CurrentHealth=Math.Clamp(PlayerStats.instance.CurrentHealth+cureAmount,0,PlayerStats.instance.MaxHealth.getValue());
                cureTime--;
                State_UI_Observer.instance.UpdateHealthUI();
                
            }
            else
            {
                Debug.Log("无法治疗");
            }
                
        }
    }

       private void showBag()
    {
        // Debug.Log("这里可以写说明,在GameManager中写明");
        {
            EquipmentBag.SetActive(!openBag);
            StashBag.SetActive(!openBag);
        }
        openBag=!openBag;
    }
}
