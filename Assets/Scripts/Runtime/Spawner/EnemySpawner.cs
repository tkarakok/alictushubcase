using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : Spawner
{
    public override void Spawn(float radius)
    {
        var enemy = ObjectPoolManager.Instance.ObjectPoolController.GetPool(PoolType.Enemy).Data.GetPoolObject()
            .GetComponent<Enemy>();
        enemy.SpawnObject(GetRandomSpawnPosition(radius));
    }

    public override Vector3 GetRandomSpawnPosition(float radius)
    {
        Vector2 randomCircle = Random.onUnitSphere * radius * 1.5f;
        Vector3 spawnPosition = new Vector3(GameManager.Instance.Player.transform.position.x  + randomCircle.x, GameManager.Instance.Player.transform.position.y, GameManager.Instance.Player.transform.position.z + randomCircle.y);
        
        return spawnPosition;
    }

}
