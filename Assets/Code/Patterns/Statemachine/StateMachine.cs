using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public AbstractUnit actor;

    protected void GetActor<T>() where T : AbstractUnit
    {
        actor = GetComponent<T>();
    }

    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnExitState();
    public abstract void OnFixUpdate();
}
