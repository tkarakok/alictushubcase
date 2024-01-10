using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateController))]
public class GameManager : Singleton<GameManager>
{
    public IGameStateController _gameStateController { get; private set; }
    [SerializeField] private Player _player;
    public Player Player => _player;
    
    public int CoinCounter { get; private set; }
    public int KillCounter { get; private set; }

    private void Awake()
    {
        _gameStateController = GetComponent<GameStateController>();
    }

    private void OnEnable()
    {
        EventManager.Instance.EventController.GetEvent<CollectCoin>().Data.AddListener(IncreaseCoinCounter);
        EventManager.Instance.EventController.GetEvent<KillEvent>().Data.AddListener(IncreaseKillCounter);
        // EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.AddListener(ChangeGameState);
    }

    private void OnDisable()
    {
        EventManager.Instance.EventController.GetEvent<CollectCoin>().Data.RemoveListener(IncreaseCoinCounter);
        EventManager.Instance.EventController.GetEvent<KillEvent>().Data.RemoveListener(IncreaseKillCounter);
        // EventManager.Instance.EventController.GetEvent<GameStateEvent>().Data.RemoveListener(ChangeGameState);
    }

    public void ChangeGameState(GameStates state)
    {
        _gameStateController.SetNewGameState(state);
    }

    #region Coin_Functions

    public void IncreaseCoinCounter()
    {
        CoinCounter += 1;
    }

    public void DecreaseCoinCounter(int decreaseAmount)
    {
        CoinCounter -= decreaseAmount;
    }

    #endregion
    
    #region Kill_Functions

    public void IncreaseKillCounter()
    {
        KillCounter += 1;
    }

    public void DecreaseKillCounter(int decreaseAmount)
    {
        KillCounter -= decreaseAmount;
    }

    #endregion
}