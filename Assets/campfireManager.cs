using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class campfireManager : MonoBehaviour
{
    public static campfireManager instance;
    // public campfire[] allcampfires; // 存储所有的篝火
    public List<campfire> unlockedcampfires = new List<campfire>(); // 存储已解锁的篝火
    public Vector3 spawnPoint;
    void Awake()
    {
        instance = this;
        // allcampfires=FindObjectsOfType<campfire>();
    }
    void Start()
    {
        spawnPoint = Player.instance.transform.position;
    }

    public void UnlockCampfire(campfire newcampfire)
    {
        unlockedcampfires.Add(newcampfire);
    }
    public void transmit1()
    {

        Debug.Log("应该被传送走一");
        campfire destination = unlockedcampfires.Find(obj => obj.Name == "营火一");
        if(destination!=null)
        {
            // Debug.Log("找到了营火一");
             Player.instance.transform.position=destination.transform.position;
        }

       
    }
        public void transmit2()
        {
            Debug.Log("应该被传送走2");
            campfire destination = unlockedcampfires.Find(obj => obj.Name == "营火二");
            if(destination!=null)
        {
            // Debug.Log("找到了营火二");
             Player.instance.transform.position=destination.transform.position;
        }
        }
    }
