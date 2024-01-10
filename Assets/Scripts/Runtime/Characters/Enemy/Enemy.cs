using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, ISpawner
{
    public void SpawnObject(Vector3 spawnPos)
    {
        transform.position = spawnPos;
    }
}
