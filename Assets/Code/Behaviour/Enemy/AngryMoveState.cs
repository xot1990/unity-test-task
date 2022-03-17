using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryMoveState : StateMachine
{
    private Enemy enemy;
    Vector3 startPosition;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }



    public override void OnEnterState()
    {
        startPosition = transform.position;
        enemy.motionSpeed *= 2;
    }

    public override void OnExitState()
    {
        enemy.motionSpeed /= 2;
        enemy.playerTile = null;
    }

    public override void OnUpdateState()
    {
        transform.Translate((enemy.playerTile.worldPosition - startPosition).normalized * Time.deltaTime * enemy.motionSpeed);

        

        if (transform.position.x < enemy.playerTile.worldPosition.x + 0.05f && transform.position.x > enemy.playerTile.worldPosition.x - 0.05f)
            if (transform.position.y < enemy.playerTile.worldPosition.y + 0.05f && transform.position.y > enemy.playerTile.worldPosition.y - 0.05f)
            {
                transform.position = enemy.playerTile.worldPosition;
                enemy.ChangeState<IdleEnemyState>();
            }
    }

    public override void OnFixUpdate()
    {

    }

    
}
