using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttack 
{
    IEnumerator AttackCoroutine();
    void SetCanAttack(bool param);
    void SetOnAttackAnim(bool param);

    Transform GetFirePoint();
    int GetDamage();
}
