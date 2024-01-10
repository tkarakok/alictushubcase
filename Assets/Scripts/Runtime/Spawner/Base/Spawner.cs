using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner 
{
    public abstract void Spawn(float radius);

    public abstract Vector3 GetRandomSpawnPosition(float radius);
}

