using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestate_Nuclear : IState
{
    private GameManager _gameManager;

    public Gamestate_Nuclear(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void OnEnter()
    {
        if(_gameManager.spawningActive)
            _gameManager.StartSpawnItemsRandomly();
    }

    public void OnExit()
    {
            _gameManager.StopSpawnItemsRandomly();
    }

    public void Tick()
    {

    }


}
