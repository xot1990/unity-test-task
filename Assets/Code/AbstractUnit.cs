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
    protected Game _game;
    public float motionSpeed;
    public Dictionary<string, Sprite> sprites;

    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        OnStart();
    }
    
    void Update()
    {
        if (!_game.isPause)
        {
            state?.OnUpdateState();
            OnUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (!_game.isPause)
        {
            state?.OnFixUpdate();
            OnFixUpdate();
        }
    }

    public void ChangeState<T>() where T : StateMachine
    {
        if (state != null)
            state.OnExitState();
        state = GetComponentInChildren<T>();
        state.OnEnterState();
    }

    protected virtual void OnStart()
    {
        map = Map.Get();
        _game = Game.Get();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnUpdate() { }
    protected virtual void OnFixUpdate() { }
}
