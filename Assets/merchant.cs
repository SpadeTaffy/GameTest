using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class merchant : MonoBehaviour
{
    public bool canSpeak=false;
    public string BlockName;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(canSpeak)
            {
                Flowchart flowchart = GameManager.FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
                if(flowchart.HasBlock(BlockName))
                {
                    flowchart.ExecuteBlock(BlockName);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("玩家进入");
        canSpeak=true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("玩家退出");
        canSpeak=false;
    }

    public void trade()
    {
        Debug.Log("这里应该进行交易");
    }
}
