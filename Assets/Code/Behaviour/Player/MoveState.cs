using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachine
{   
    public Vector3 targetPosition;
    private Map _map;

    private void Awake()
    {
        GetActor<AbstractUnit>();
        _map = Map.Get();
    }

    public override void OnEnterState()
    {
        TileCustom currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));

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
                break;
            case AbstractUnit.MotionFlag.Left:
                break;
            case AbstractUnit.MotionFlag.Down:
                break;
        }
    }

    public override void OnExitState()
    {

    }

    public override void OnUpdateState()
    {
        transform.Translate((targetPosition - transform.position) *Time.deltaTime * actor.motionSpeed);


        if (transform.position.x < targetPosition.x + 0.05f && transform.position.x > targetPosition.x - 0.05f)
            if (transform.position.y < targetPosition.y + 0.05f && transform.position.y > targetPosition.y - 0.05f)
            {
                transform.position = targetPosition;
                actor.ChangeState<IdleState>();
            }
    }

    public override void OnFixUpdate()
    {

    }

}
