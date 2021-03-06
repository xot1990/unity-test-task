using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachine
{
    private void Awake()
    {
        GetActor<AbstractUnit>();
    }


    public override void OnEnterState()
    {
        
    }

    public override void OnExitState()
    {
        
    }

    public override void OnUpdateState()
    {
        if (InputManager.GetUiKeyDown(InputManager.UiKey.UpArrow))
        {
            actor.motionFlag = AbstractUnit.MotionFlag.Up;
            actor.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.DownArrow))
        {
            actor.motionFlag = AbstractUnit.MotionFlag.Down;
            actor.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.LeftArrow))
        {
            actor.motionFlag = AbstractUnit.MotionFlag.Left;
            actor.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.RightArrow))
        {
            actor.motionFlag = AbstractUnit.MotionFlag.Right;
            actor.ChangeState<MoveState>();
        }

        if (InputManager.GetUiKeyDown(InputManager.UiKey.Ulty))
        {
            actor.ChangeState<BombPlantState>();
        }
    }

    public override void OnFixUpdate()
    {
        
    }
    
}
