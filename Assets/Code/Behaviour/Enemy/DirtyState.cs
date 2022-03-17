using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyState : StateMachine
{
    private Enemy _enemy;
    public float dirtyTime = 2;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void OnEnterState()
    {
        _enemy.SpriteSwap(_enemy.motionFlag, Enemy.State.Dirty);
    }

    public override void OnExitState()
    {
        dirtyTime = 2;
    }

    public override void OnUpdateState()
    {
        dirtyTime -= Time.deltaTime;

        if (dirtyTime <= 0)
        {
            _enemy.ChangeState<IdleEnemyState>();
        }
    }

    public override void OnFixUpdate()
    {

    }

}
