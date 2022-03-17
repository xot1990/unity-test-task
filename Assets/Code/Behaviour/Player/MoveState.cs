using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachine
{   
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Map _map;

    private void Awake()
    {
        GetActor<player>();
        _map = Map.Get();
    }

    public override void OnEnterState()
    {
        TileCustom currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
        currentPosition = transform.position;

        switch (actor.motionFlag)
        {
            case AbstractUnit.MotionFlag.Up:
                if (currentTile.tileNumber.y + 1 < _map.sizeY)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y + 1)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y + 1)).worldPosition;
                    else actor.ChangeState<IdleState>();
                else actor.ChangeState<IdleState>();
                break;
            case AbstractUnit.MotionFlag.Right:
                if (currentTile.tileNumber.x + 1 < _map.sizeX)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).worldPosition;
                    else actor.ChangeState<IdleState>();
                else actor.ChangeState<IdleState>();
                break;
            case AbstractUnit.MotionFlag.Left:
                if (currentTile.tileNumber.x - 1 >= 0)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).worldPosition;
                    else actor.ChangeState<IdleState>();
                else actor.ChangeState<IdleState>();
                break;
            case AbstractUnit.MotionFlag.Down:
                if (currentTile.tileNumber.y - 1 >= 0)
                    if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).isRock)
                        targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).worldPosition;
                    else actor.ChangeState<IdleState>();
                else actor.ChangeState<IdleState>();
                break;
        }
    }

    public override void OnExitState()
    {

    }

    public override void OnUpdateState()
    {
        transform.Translate((targetPosition - currentPosition) *Time.deltaTime * actor.motionSpeed);


        if (transform.position.x < targetPosition.x + 0.05f && transform.position.x > targetPosition.x - 0.05f)
            if (transform.position.y < targetPosition.y + 0.05f && transform.position.y > targetPosition.y - 0.05f)
            {
                _map.GetTile(_map.WorldToMapPosition(targetPosition)).isPlayerHere = true;
                _map.GetTile(_map.WorldToMapPosition(currentPosition)).isPlayerHere = false;
                transform.position = targetPosition;
                actor.ChangeState<IdleState>();
            }
    }

    public override void OnFixUpdate()
    {

    }

}
