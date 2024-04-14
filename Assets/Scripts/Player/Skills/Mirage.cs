using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mirage : Skill
{
    public Transform playerPosition;
    public GameObject MirageSprite;
    private GameObject mirage;




    public override void Update()
    {
        // base.Update();
        
    }

    public override void useSkill()
    {
        mirage=Instantiate(MirageSprite,playerPosition.position,playerPosition.rotation);
        mirage.transform.localScale=playerPosition.localScale;
    }
    
}
