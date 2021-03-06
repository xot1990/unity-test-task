using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUnit : MonoBehaviour
{
    public enum MotionFlag
    {
        Up,
        Down,
        Left,
        Right
    }

    public MotionFlag motionFlag;
    public StateMachine state;
    public Map map;
    public float motionSpeed;

    void Start()
    {
        OnStart();
    }
    
    void Update()
    {
        state.OnUpdateState();    
    }

    private void FixedUpdate()
    {
        state.OnFixUpdate();
    }

    public void ChangeState<T>() where T : StateMachine
    {
        if (state != null)
            state.OnExitState();
        state = GetComponentInChildren<T>();
        state.OnEnterState();
    }

    protected void OnStart()
    {
        map = Map.Get();
        ChangeState<IdleState>();
    }
}
