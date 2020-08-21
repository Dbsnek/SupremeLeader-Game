using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    public List<PlayerInput> playerInputs = new List<PlayerInput>();
    public PlayerPanel[] playerPanels { get; set; }

    private bool NormalStateForLevelIsActive = true;
    public bool spawningActive;

    public event Action OnBombSpawn;

    public event Action <Player> OnPlayerJoinedNotice;
    public Transform[] spawnPoints;
    private int spawnpointNumber = 0;
    private void Awake()
    {
        Application.targetFrameRate = 120;

        _stateMachine = new StateMachine();

        var nuclear = new Gamestate_Nuclear(this);
        var playerselect = new Gamestate_Playerselect(this);

        _stateMachine.SetState(nuclear);

        void AddTransition(IState from, IState to, Func<bool> condition)
        {
            _stateMachine.AddTransition(from, to, condition);
        }


    }
    void Update()
    {
        _stateMachine.Tick();
    }


    public void StartSpawnItemsRandomly()
    {
        StartCoroutine(SpawnItemsRandomly());
    }

    public void StopSpawnItemsRandomly()
    {
        StopCoroutine(SpawnItemsRandomly());
    }


    private IEnumerator SpawnItemsRandomly()
    {
        while(NormalStateForLevelIsActive)
        {
            if(OnBombSpawn != null)
            {
                OnBombSpawn();
            }
            float waitTime = UnityEngine.Random.Range(5, 15);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (playerInput != null)
        {
            playerInputs.Add(playerInput);
            Player player = playerInput.GetComponent<Player>();
            player.spawnPoint = spawnPoints[spawnpointNumber];
            spawnpointNumber++;

            if (OnPlayerJoinedNotice != null)
                OnPlayerJoinedNotice(player);
            
        }
    }


}



  