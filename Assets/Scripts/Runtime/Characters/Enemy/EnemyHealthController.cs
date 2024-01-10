using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyHealthController : CharacterHealthController, IEnemyHealth
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (IsDead)
        {
            GetComponentInChildren<ParticleSystem>().Play();
            DOVirtual.DelayedCall(1f, () =>
            {
                transform.DOScale(Vector3.zero, .3f).SetEase(Ease.Flash).OnComplete(() =>
                {
                    GetComponent<PoolObject>().ResetObject();
                });
            });
            EventManager.Instance.EventController.GetEvent<KillEvent>().Data.Execute();
            EventManager.Instance.EventController.GetEvent<UIInfoEvent>().Data.Execute();
        }
    }
}
