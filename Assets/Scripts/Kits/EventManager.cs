using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{

    
    // private static EventManager instance;
    public static EventManager Instance=new EventManager();
    // {
    //     get
    //     {
    //         if(instance==null)
    //         {
    //             instance=new EventManager();
    //         }
    //         return instance; 
    //     }
    // }
    // void Start()
    // {
    //     Instance=this;
    // }

    private Dictionary<string,EventInfo> EventDic = new Dictionary<string, EventInfo>();


    public class EventInfo
    {
        public UnityAction actions;
        public EventInfo(UnityAction action)
        {
            actions += action;
        }
    }

    public void AddEventListener(string name,UnityAction action)
    {
        if(EventDic.ContainsKey(name))
        {
            EventDic[name].actions+=action;
        }
        else
        {
            EventDic.Add(name,new EventInfo(action));
        }
    }

    public void EventTrigger(string name)
    {
        if(EventDic.ContainsKey(name))
        {
            EventDic[name].actions.Invoke();
        }
    }
    

 
}
