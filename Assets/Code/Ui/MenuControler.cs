using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    private Game _game;
    public GameObject menu;

    private void Awake()
    {
        _game = Game.Get();
    }

    public void StartGame()
    {
        _game.isPause = false;
        menu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
