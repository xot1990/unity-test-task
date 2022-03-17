using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : StateMachine
{
    public TileCustom currentTile;
    public TileCustom pastTile;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private Map _map;

    private void Awake()
    {
        GetActor<Enemy>();
        _map = Map.Get();
    }

    private void Start()
    {        
        pastTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
    }

    public override void OnEnterState()
    {
        currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));

        List<AbstractUnit.MotionFlag>  motionFlags = CheckMotionCan();        
        actor.motionFlag = motionFlags[Random.Range(0, motionFlags.Count)];

        if (motionFlags.Count > 0)
            actor.ChangeState<MoveEnemyState>();
    }

    public override void OnExitState()
    {
        pastTile = currentTile;
        currentTile = null;
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnFixUpdate()
    {
        
    }

    private List<AbstractUnit.MotionFlag> CheckMotionCan()
    {
        List<AbstractUnit.MotionFlag> motions = new List<AbstractUnit.MotionFlag>();

        if (currentTile.tileNumber.y + 1 < _map.sizeY)
            if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y + 1)).isRock)
                if (currentTile.tileNumber.y + 1 != pastTile.tileNumber.y)
                {
                    motions.Add(AbstractUnit.MotionFlag.Up);
                }

        if (currentTile.tileNumber.x + 1 < _map.sizeX)
            if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).isRock)
                if (currentTile.tileNumber.x + 1 != pastTile.tileNumber.x)
                {
                    motions.Add(AbstractUnit.MotionFlag.Right);
                }

        if (currentTile.tileNumber.x - 1 >= 0)
            if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).isRock)
                if (currentTile.tileNumber.x - 1 != pastTile.tileNumber.x)
                {
                    motions.Add(AbstractUnit.MotionFlag.Left);
                }

        if (currentTile.tileNumber.y - 1 >= 0)
            if (!_map.GetTile(new Vector2Int(currentTile.tileNumber.x, currentTile.tileNumber.y - 1)).isRock)
                if (currentTile.tileNumber.y - 1 != pastTile.tileNumber.y)
                {
                    motions.Add(AbstractUnit.MotionFlag.Down);
                }

        return motions;
    }

   
}
