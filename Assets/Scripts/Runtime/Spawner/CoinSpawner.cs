using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinSpawner : Spawner
{
    
    public override void Spawn(float radius)
    {
        var coin = ObjectPoolManager.Instance.ObjectPoolController.GetPool(PoolType.Coin).Data.GetPoolObject()
            .GetComponent<Coin>();
        coin.transform.localScale = Vector3.zero;
        coin.SpawnObject(GetRandomSpawnPosition(radius));
    }

    public override Vector3 GetRandomSpawnPosition(float radius)
    {
        float x = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);

        Vector3 spawnPosition = new Vector3(GameManager.Instance.Player.transform.position.x + x, GameManager.Instance.Player.transform.position.y + 1, GameManager.Instance.Player.transform.position.z + z);

        return spawnPosition;
    }

}
