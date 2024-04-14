using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState:State
{

    protected Player player;



    public PlayerState(StateMachine stateMachine, Player player, string Name)
    {
        this.stateMachine = stateMachine;
        this.player = player;
        this.Name = Name;
    }

}

