using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class SpawnController : MonoBehaviour, ISpawnerController
{
    [Inject] private EnemySpawner _enemySpawner;
    [Inject] private CoinSpawner _coinSpawner;

    [SerializeField] private float _spawnAreaRadius;
    [SerializeField] private int _gameStartInitCoinCount;
    [SerializeField] private int _gameStartInitEnemyCount;

    [Header("Enemy Spawn Settings")]
    [SerializeField] private float _spawnEnemyTimer;
    [SerializeField] private int _maxEnemy;
    private int _enemyCounter;

    [Header("Coin Spawn Settings")]
    [SerializeField] private float _spawnCoinTimer;
    [SerializeField] private int _maxCoin;
    
    private int _coinCounter;

    private void Start()
    {
        DOVirtual.DelayedCall(.5f, () =>
        {
            StartCoroutine(SpawnEnemyCoroutine());
            StartCoroutine(SpawnCoinCoroutine());
        });
    }

    private void OnEnable()
    {
        EventManager.Instance.EventController.GetEvent<KillEvent>().Data.AddListener(DecreaseEnemyCounter);
        EventManager.Instance.EventController.GetEvent<CollectCoin>().Data.AddListener(DecreaseCoinCounter);
    }

    public void SpawnEnemy(int total)
    {
        for (int i = 0; i < total; i++)
        {
            IncreaseEnemyCounter();
            _enemySpawner.Spawn(_spawnAreaRadius);
        }
    }

    public void SpawnCoin(int total)
    {
        for (int i = 0; i < total; i++)
        {
            IncreaseCoinCounter();
            _coinSpawner.Spawn(_spawnAreaRadius);
        }
    }

    #region COIN_ENEMY_COUNTER_FUNCS

    public void IncreaseEnemyCounter()
    {
        _enemyCounter += 1;
    }

    public void DecreaseEnemyCounter()
    {
        _enemyCounter -= 1;
    }

    public void IncreaseCoinCounter()
    {
        _coinCounter += 1;
    }

    public void DecreaseCoinCounter()
    {
        _coinCounter -= 1;
    }

    public IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            if (_enemyCounter < _maxEnemy)
            {
                int value = _maxEnemy - _enemyCounter;
                SpawnEnemy(value);
                yield return new WaitForSeconds(_spawnEnemyTimer);
            }
            else
                yield return null;
        }
    }

    public IEnumerator SpawnCoinCoroutine()
    {
        while (true)
        {
            if (_coinCounter < _maxCoin)
            {
                int value = _maxCoin - _coinCounter;
                SpawnCoin(value);
                yield return new WaitForSeconds(_spawnCoinTimer);
            }
            else
                yield return null;
        }
    }

    #endregion
    
    
}