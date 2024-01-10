using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class EnemyThrowAnimationEvent : AnimationEvent
{
    private EnemyAttackController _enemyAttackController;
    private EnemyMovementController _enemyMovementController;
    public override void Start()
    {
        base.Start();
        _enemyAttackController = GetComponentInParent<EnemyAttackController>();
        _enemyMovementController = GetComponentInParent<EnemyMovementController>();
    }

    public override void DoAnimationEvent()
    {
        base.DoAnimationEvent();
        var bullet = ObjectPoolManager.Instance.ObjectPoolController.GetPool(PoolType.EnemyBullet).Data
            .GetPoolObject();
        bullet.transform.position = _enemyAttackController.GetFirePoint().position;

        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        enemyBullet.SetDamage(_enemyAttackController.GetDamage());
            
        Vector3 dir = ((GameManager.Instance.Player.transform.position + Vector3.up) - bullet.transform.position).normalized;
        enemyBullet.ForceBullet(dir);
        DOVirtual.DelayedCall(1, () => _enemyMovementController.SetCanMove(true));
    }

}
