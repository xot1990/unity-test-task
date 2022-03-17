using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPanelControler : MonoBehaviourService<UiPanelControler>
{
    public GuiPointerListener jump;
    public GuiPointerListener upArrow;
    public GuiPointerListener sqaut;
    public GuiPointerListener leftArrow;
    public GuiPointerListener rightArrow;
    public GuiPointerListener downArrow;
    public GuiPointerListener sword;
    public GuiPointerListener dron;
    public GuiPointerListener ulty;
    public GuiPointerListener pause;

    protected override void OnCreateService()
    {
        SetListener(upArrow, InputManager.upArrow);
        SetListener(leftArrow, InputManager.leftArrow);
        SetListener(rightArrow, InputManager.rightArrow);
        SetListener(downArrow, InputManager.downArrow);
        SetListener(ulty, InputManager.ulty);
        /*
        SetListener(jump, InputManager.jump);
        SetListener(sword, InputManager.sword);
        SetListener(dron, InputManager.dron);
        SetListener(pause, InputManager.pause);
        SetListener(sqaut, InputManager.sqaut);*/
    }

    protected override void OnDestroyService()
    {
    }

    private void SetListener(GuiPointerListener guiPointerListener, InputManager.BoolSteck boolSteck)
    {
        guiPointerListener.OnDown += data => { boolSteck.isDo = true; boolSteck.isDown = true; };
        guiPointerListener.OnUp += data => { boolSteck.isDo = false; boolSteck.isUp = true; };
    }

    private void SetFalse(InputManager.BoolSteck boolSteck)
    {
        boolSteck.isUp = false;
        boolSteck.isDown = false;
    }

    private void LateUpdate()
    {
        SetFalse(InputManager.upArrow);
        SetFalse(InputManager.rightArrow);
        SetFalse(InputManager.leftArrow);
        SetFalse(InputManager.downArrow);
        SetFalse(InputManager.ulty);
        /*
        SetFalse(InputManager.jump);
        SetFalse(InputManager.sword);
        SetFalse(InputManager.dron);
        SetFalse(InputManager.pause);
        SetFalse(InputManager.sqaut);*/
    }
}
