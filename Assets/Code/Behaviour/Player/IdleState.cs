using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachine
{
    public TileCustom currentTile;
    private Player _player;
    private Map _map;

    private void Awake()
    {
        _map = Map.Get();
        _player = GetComponent<Player>();
    }


    public override void OnEnterState()
    {
        currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
    }

    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        if (InputManager.GetUiKeyDown(InputManager.UiKey.UpArrow))
        {
            _player.motionFlag = AbstractUnit.MotionFlag.Up;
            _player.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.DownArrow))
        {
            _player.motionFlag = AbstractUnit.MotionFlag.Down;
            _player.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.LeftArrow))
        {
            _player.motionFlag = AbstractUnit.MotionFlag.Left;
            _player.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.RightArrow))
        {
            _player.motionFlag = AbstractUnit.MotionFlag.Right;
            _player.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.Ulty) && _player.bombTimer < 0)
        {
            _player.ChangeState<BombPlantState>();
        }
    }

    public override void OnFixUpdate()
    {
        
    }
    
}
