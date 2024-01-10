using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnerController
{
    void SpawnEnemy(int total);
    void SpawnCoin(int total);
    void IncreaseEnemyCounter();
    void DecreaseEnemyCounter();
    void IncreaseCoinCounter();
    void DecreaseCoinCounter();

    IEnumerator SpawnEnemyCoroutine();
    IEnumerator SpawnCoinCoroutine();
}
