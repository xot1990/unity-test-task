using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlantState : StateMachine
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public override void OnEnterState()
    {
        Instantiate(_player.bomb, transform.position, Quaternion.identity);
        _player.bombTimer = 2;
        _player.ChangeState<IdleState>();
    }

    public override void OnExitState()
    {

    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixUpdate()
    {

    }

}
