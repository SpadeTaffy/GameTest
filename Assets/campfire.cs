using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Fungus;
using System;

public class campfire : MonoBehaviour
{
    public string Name;
    public string BlockName;
    [SerializeField] bool isActive;
    bool inCampFire;
    public GameObject HintButton;
    Flowchart flowchart;
    void Start()
    {
        HintButton.SetActive(false);
        flowchart = GameManager.FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
    }
    void Update()
    {
        if (inCampFire)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                isActive = true;
                setFungusBoolVariable(this.Name);
                GetComponent<SpriteRenderer>().color = Color.red;
                campfireManager.instance.spawnPoint = transform.position;
                
                if (!campfireManager.instance.unlockedcampfires.Find(obj => obj.Name == this.Name))
                {
                    Debug.Log("已点燃篝火" + this.Name);
                    campfireManager.instance.UnlockCampfire(this);
                    // BooleanVariable boolVariable = (BooleanVariable)FungusManager.Instance.GlobalVariables.GetVariable("trans1");
                    //   boolVariable.Value = true;
                    
                }
                else
                {
                    // Debug.Log("你已经点燃篝火了");

                    if (flowchart.HasBlock(BlockName))
                    {
                        flowchart.ExecuteBlock(BlockName);
                    }
                }

                // foreach (campfire camp in campfireManager.instance.unlockedcampfires)
                // {
                //     if (camp.Name == this.Name)
                //     {
                //         Debug.Log("这个是营火" + this.Name);
                //     }
                // }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            inCampFire = true;
            Debug.Log("进入篝火");
            HintButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCampFire = false;
            Debug.Log("离开篝火");
            HintButton.SetActive(false);
        }
    }

    private void setFungusBoolVariable(String name)
    {
        if(name=="营火一")
            flowchart.SetBooleanVariable("trans1",true);
        else if(name=="营火二")
            flowchart.SetBooleanVariable("trans2",true);
    }

}
