using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachine
{   
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Player _player;
    private Map _map;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _map = Map.Get();
    }

    public override void OnEnterState()
    {
        TileCustom currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
        currentPosition = transform.position;

        switch (_player.motionFlag)
        {
            case AbstractUnit.MotionFlag.Up:

                _player.SpriteSwapOnFlag(AbstractUnit.MotionFlag.Up,_player.walk);

                if (currentTile.tileNumber.y + 1 < _map.sizeY)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y + 1)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y + 1)).worldPosition;
                    else _player.ChangeState<IdleState>();
                else _player.ChangeState<IdleState>();

                break;
            case AbstractUnit.MotionFlag.Right:

                _player.SpriteSwapOnFlag(AbstractUnit.MotionFlag.Right, _player.walk);

                if (currentTile.tileNumber.x + 1 < _map.sizeX)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).worldPosition;
                    else _player.ChangeState<IdleState>();
                else _player.ChangeState<IdleState>();

                break;
            case AbstractUnit.MotionFlag.Left:

                _player.SpriteSwapOnFlag(AbstractUnit.MotionFlag.Left, _player.walk);

                if (currentTile.tileNumber.x - 1 >= 0)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).worldPosition;
                    else _player.ChangeState<IdleState>();
                else _player.ChangeState<IdleState>();

                break;
            case AbstractUnit.MotionFlag.Down:

                _player.SpriteSwapOnFlag(AbstractUnit.MotionFlag.Down, _player.walk);

                if (currentTile.tileNumber.y - 1 >= 0)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).worldPosition;
                    else _player.ChangeState<IdleState>();
                else _player.ChangeState<IdleState>();

                break;
        }
    }

    public override void OnExitState()
    {

    }

    public override void OnUpdateState()
    {
        transform.Translate((targetPosition - currentPosition) *Time.deltaTime * _player.motionSpeed);


        if (transform.position.x < targetPosition.x + 0.05f && transform.position.x > targetPosition.x - 0.05f)
            if (transform.position.y < targetPosition.y + 0.05f && transform.position.y > targetPosition.y - 0.05f)
            {
                _map.GetTile(_map.WorldToMapPosition(targetPosition)).isPlayerHere = true;
                _map.GetTile(_map.WorldToMapPosition(currentPosition)).isPlayerHere = false;
                transform.position = targetPosition;
                _player.ChangeState<IdleState>();
            }
    }

    public override void OnFixUpdate()
    {

    }

}
