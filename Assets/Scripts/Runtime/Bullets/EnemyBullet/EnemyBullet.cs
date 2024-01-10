using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyBullet : Bullet,IEnemyBullet
{
    private Tween _tween;
    
    public void ForceBullet(Vector3 dir)
    {
        _rigidbody.velocity = dir * 10;
        _tween = DOVirtual.DelayedCall(3, ResetObject);
    }
}
