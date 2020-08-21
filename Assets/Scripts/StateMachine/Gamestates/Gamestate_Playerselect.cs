using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
public class Gamestate_Playerselect : IState
{
    private GameManager _gameManager;

    

    public Gamestate_Playerselect(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void OnEnter()
    {
        _gameManager.playerPanels = UnityEngine.Object.FindObjectsOfType<PlayerPanel>().OrderBy(t => t.playerNumber).ToArray();
        _gameManager.OnPlayerJoinedNotice += _gameManager_OnPlayerJoinedNotice;
    }

    private void _gameManager_OnPlayerJoinedNotice(Player player)
    {
        AssignControllerToPlayerPanel(player);
    }

    public void OnExit()
    {
        _gameManager.OnPlayerJoinedNotice -= _gameManager_OnPlayerJoinedNotice;
    }

    public void Tick()
    {
        
    }

    public Player AssignControllerToPlayerPanel(Player player)
    {
        Debug.Log("Assigning controllers");
        for (int i = 0; i < _gameManager.playerPanels.Length; i++)
        {
            if (_gameManager.playerPanels[i].HasControllerAssigned == false)
            {
                Debug.Log("Assigining player to Playerpanel " + i);
                return _gameManager.playerPanels[i].AssignController(player);
            }
        }
        return null;
    }

}
