using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttack
{
    void GetEnemies();
    bool HasAliveTargetInRange();
}
