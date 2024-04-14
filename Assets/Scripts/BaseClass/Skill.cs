using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]protected float cooldownTime;
    [SerializeField]protected float cooldownCounter;

    
    public virtual void Update()
    {
        if(cooldownCounter>0)
        {
            cooldownCounter-=Time.deltaTime;
        }
    }

    public virtual void useSkill()
    {
    }
}
