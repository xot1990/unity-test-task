using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyState : StateMachine
{   
    public Vector3 targetPosition;
    public Vector3 currentPosition;
    private Enemy _enemy;
    private Map _map;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _map = Map.Get();
    }

    public override void OnEnterState()
    {
        TileCustom currentTile = _map.GetTile(_map.WorldToMapPosition(transform.position));
        currentPosition = transform.position;

        switch (_enemy.motionFlag)
        {
            case AbstractUnit.MotionFlag.Up:

                _enemy.SpriteSwap(AbstractUnit.MotionFlag.Up, Enemy.State.Walk);

                for (int i = currentTile.tileNumber.y; i < _map.sizeY; i++)
                {
                    if (_map._tiles[currentTile.tileNumber.x, i].isPlayerHere)
                    {
                        _enemy.playerTile = _map._tiles[currentTile.tileNumber.x, i];
                        _enemy.SpriteSwap(AbstractUnit.MotionFlag.Up, Enemy.State.Angry);
                        _enemy.ChangeState<AngryMoveState>();
                    }
                }

                targetPosition = _map._tiles[currentTile.tileNumber.x, currentTile.tileNumber.y + 1].worldPosition;

                break;
            case AbstractUnit.MotionFlag.Right:

                _enemy.SpriteSwap(AbstractUnit.MotionFlag.Right, Enemy.State.Walk);

                for (int i = currentTile.tileNumber.x; i < _map.sizeX; i++)
                {
                    if (_map._tiles[i, currentTile.tileNumber.y].isPlayerHere)
                    {
                        _enemy.playerTile = _map._tiles[i, currentTile.tileNumber.y];
                        _enemy.SpriteSwap(AbstractUnit.MotionFlag.Right, Enemy.State.Angry);
                        _enemy.ChangeState<AngryMoveState>();
                    }
                }

                targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x + 1, currentTile.tileNumber.y)).worldPosition;

                break;
            case AbstractUnit.MotionFlag.Left:

                _enemy.SpriteSwap(AbstractUnit.MotionFlag.Left, Enemy.State.Walk);

                for (int i = currentTile.tileNumber.x; i > 0; i--)
                {
                    if (_map._tiles[i, currentTile.tileNumber.y].isPlayerHere)
                    {
                        _enemy.playerTile = _map._tiles[i, currentTile.tileNumber.y];
                        _enemy.SpriteSwap(AbstractUnit.MotionFlag.Left, Enemy.State.Angry);
                        _enemy.ChangeState<AngryMoveState>();
                    }
                }

                targetPosition = _map.GetTile(new Vector2Int(currentTile.tileNumber.x - 1, currentTile.tileNumber.y)).worldPosition;

                break;
            case AbstractUnit.MotionFlag.Down:

                _enemy.SpriteSwap(AbstractUnit.MotionFlag.Down, Enemy.State.Walk);

                for (int i = currentTile.tileNumber.y; i > 0; i--)
                {
                    if (_map._tiles[currentTile.tileNumber.x, i].isPlayerHere)
                    {
                        _enemy.playerTile = _map._tiles[currentTile.tileNumber.x, i];
                        _enemy.SpriteSwap(AbstractUnit.MotionFlag.Down, Enemy.State.Angry);
                        _enemy.ChangeState<AngryMoveState>();
                    }
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
        transform.Translate((targetPosition - currentPosition) *Time.deltaTime * _enemy.motionSpeed);

        if (transform.position.x < targetPosition.x + 0.05f && transform.position.x > targetPosition.x - 0.05f)
            if (transform.position.y < targetPosition.y + 0.05f && transform.position.y > targetPosition.y - 0.05f)
            {
                transform.position = targetPosition;
                _enemy.ChangeState<IdleEnemyState>();
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
