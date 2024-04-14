using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonState:State
{
    protected Skeleton skeleton;

    public SkeletonState(StateMachine stateMachine, Skeleton skeleton, string Name)
    {
        this.stateMachine = stateMachine;
        this.skeleton = skeleton;
        this.Name = Name;
    }

}

