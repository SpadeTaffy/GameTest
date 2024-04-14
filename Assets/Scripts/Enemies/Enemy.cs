using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject attackAlert;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }

    public void openAttackAlert()
    {
        attackAlert.SetActive(true);
    }

    public void closeAttackAlert()
    {
        attackAlert.SetActive(false);
    }

}
