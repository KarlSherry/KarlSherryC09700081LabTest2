using System;
using UnityEngine;

public abstract class State
{
	protected int currentAmmo = 10;
    protected GameObject myGameObject;

    public State(GameObject myGameObject)
    {
        this.myGameObject = myGameObject;
    }

    public abstract string Description();

    public abstract void Enter();
    public abstract void Exit();

    public abstract void Update();
}
