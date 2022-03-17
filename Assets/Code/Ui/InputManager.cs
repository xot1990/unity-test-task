using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public enum UiKey
    {
        Jump,
        LeftArrow,
        RightArrow,
        DownArrow,
        UpArrow,
        Sword,
        Ulty,
        Dron,
        Pause,
        Squat,
    }

    [System.Serializable]
    public class BoolSteck
    {
        public bool isDo = false;
        public bool isDown = false;
        public bool isUp = false;
    }

    public static BoolSteck jump = new BoolSteck();
    public static BoolSteck leftArrow = new BoolSteck();
    public static BoolSteck upArrow = new BoolSteck();
    public static BoolSteck rightArrow = new BoolSteck();
    public static BoolSteck downArrow = new BoolSteck();
    public static BoolSteck sword = new BoolSteck();
    public static BoolSteck ulty = new BoolSteck();
    public static BoolSteck dron = new BoolSteck();
    public static BoolSteck pause = new BoolSteck();
    public static BoolSteck sqaut = new BoolSteck();


    public static bool GetUiKey(UiKey uiKey)
    {
        switch (uiKey)
        {
            case UiKey.Jump:
                return jump.isDo;
            case UiKey.LeftArrow:
                return leftArrow.isDo;
            case UiKey.UpArrow:
                return upArrow.isDo;
            case UiKey.RightArrow:
                return rightArrow.isDo;
            case UiKey.DownArrow:
                return downArrow.isDo;
            case UiKey.Sword:
                return sword.isDo;
            case UiKey.Ulty:
                return ulty.isDo;
            case UiKey.Dron:
                return dron.isDo;
            case UiKey.Pause:
                return pause.isDo;
            case UiKey.Squat:
                return sqaut.isDo;
        }

        return false;
    }
    public static bool GetUiKeyUp(UiKey uiKey)
    {
        switch (uiKey)
        {
            case UiKey.Jump:
                return jump.isUp;
            case UiKey.LeftArrow:
                return leftArrow.isUp;
            case UiKey.UpArrow:
                return upArrow.isUp;
            case UiKey.RightArrow:
                return rightArrow.isUp;
            case UiKey.DownArrow:
                return downArrow.isUp;
            case UiKey.Sword:
                return sword.isUp;
            case UiKey.Ulty:
                return ulty.isUp;
            case UiKey.Dron:
                return dron.isUp;
            case UiKey.Pause:
                return pause.isUp;
            case UiKey.Squat:
                return sqaut.isUp;
        }

        return false;
    }
    public static bool GetUiKeyDown(UiKey uiKey)
    {
        switch (uiKey)
        {
            case UiKey.Jump:
                return jump.isDown;
            case UiKey.LeftArrow:
                return leftArrow.isDown;
            case UiKey.UpArrow:
                return upArrow.isDown;
            case UiKey.RightArrow:
                return rightArrow.isDown;
            case UiKey.DownArrow:
                return downArrow.isDown;
            case UiKey.Sword:
                return sword.isDown;
            case UiKey.Ulty:
                return ulty.isDown;
            case UiKey.Dron:
                return dron.isDown;
            case UiKey.Pause:
                return pause.isDown;
            case UiKey.Squat:
                return sqaut.isDown;
        }

        return false;
    }

}
