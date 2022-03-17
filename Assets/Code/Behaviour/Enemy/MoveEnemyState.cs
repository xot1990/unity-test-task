using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyState : StateMachine
{   
    public Vector3 targetPosition;
    public Vector3 currentPosition;
    private Map _map;

    private void Awake()
    {
        GetActor<AbstractUnit>();
        _map = Map.Get();
    }

    public override void OnEnterState()
    {
        TileCustom currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
        currentPosition = transform.position;

        switch (actor.motionFlag)
        {
            case AbstractUnit.MotionFlag.Up:
                for (int i = currentTile.tileNumber.y; i < _map.sizeY; i++)
                {
                    if (_map._tiles[currentTile.tileNumber.x, i].isPlayerHere)
                        actor.ChangeState<EngryMoveState>();
                }
                targetPosition = _map._tiles[currentTile.tileNumber.x, currentTile.tileNumber.y + 1].worldPosition;
                break;
            case AbstractUnit.MotionFlag.Right:
                for (int i = currentTile.tileNumber.x; i < _map.sizeX; i++)
                {
                    if (_map._tiles[i, currentTile.tileNumber.y].isPlayerHere)
                        actor.ChangeState<EngryMoveState>();
                }
                targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).worldPosition;
                break;
            case AbstractUnit.MotionFlag.Left:
                for (int i = currentTile.tileNumber.x; i > 0; i--)
                {
                    if (_map._tiles[i, currentTile.tileNumber.y].isPlayerHere)
                        actor.ChangeState<EngryMoveState>();
                }
                targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).worldPosition;
                break;
            case AbstractUnit.MotionFlag.Down:
                for (int i = currentTile.tileNumber.y; i > 0; i--)
                {
                    if (_map._tiles[currentTile.tileNumber.x, i].isPlayerHere)
                        actor.ChangeState<EngryMoveState>();
                }
                targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).worldPosition;
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
                transform.position = targetPosition;
                actor.ChangeState<IdleEnemyState>();
            }
    }

    public override void OnFixUpdate()
    {

    }

    private bool PlayerCheck()
    {
        return true;
    }
}
