using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyBulletCollisionController : BulletCollisionController
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamagable>().TakeDamage(_bullet.Damage);
            _bullet.ResetObject();
            DOTween.Kill(gameObject);
        }
    }
}
