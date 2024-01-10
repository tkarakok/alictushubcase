using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class PlayerAttackController : CharacterAttackController, IPlayerAttack
{
    [SerializeField] private float _checkEnemyTimer;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _targetLayerMask;


    [SerializeField] private Transform _leftBulletPoint;
    [SerializeField] private Transform _rightBulletPoint;
    private float _timer;


    private List<Collider> _enemies = new List<Collider>();
    protected IDamagable _targetDamagable;
    public GameObject _target { get; private set; }

    [Inject]
    private CircularMotion _circularMotion;
    public override void Update()
    {
        base.Update();
        if (GameManager.Instance._gameStateController.GetCurrentGameState() != GameStates.InGameState) return;
        GetEnemies();
        Attack();
    }

    public override void Attack()
    {
        if (_targetDamagable == null || _targetDamagable.GetIsDead()) return;
        if (_isCoolDown) return;

        var bullet = ObjectPoolManager.Instance.ObjectPoolController.GetPool(PoolType.PlayerBullet).Data
            .GetPoolObject();

        bullet.transform.position = _firePoint.position;
        Vector3 bulletFirstPos = _rightBulletPoint.position;
        if (Random.Range(0, 2) == 1)
        {
            bulletFirstPos = _leftBulletPoint.position;
        }

        bullet.transform.DOLocalPath(new Vector3[]
                {
                    _firePoint.position, _circularMotion.GetCirclePos(_firePoint.position, _target.transform.position),
                    _target.transform.position
                },
                20,
                PathType.CatmullRom,
                PathMode.Full3D,
                5
            ).SetLookAt(1f)
            .SetSpeedBased(true).SetEase(Ease.Flash).OnComplete(() =>
            {
                bullet.GetComponent<PoolObject>().ResetObject();
                _targetDamagable.TakeDamage(_character.CharacterData.Damage);
            });

        _isCoolDown = true;
        DOVirtual.DelayedCall(_coolDownTimer, () => _isCoolDown = false);
    }

    

    public virtual void GetEnemies()
    {
        if (_targetDamagable != null && !_targetDamagable.GetIsDead()) return;
        _timer += Time.deltaTime;
        if (_timer < _checkEnemyTimer) return;
        _timer = 0;

        _enemies = Physics.OverlapSphere(transform.position, _radius, _targetLayerMask).ToList()
            .Where(e => e.GetComponent<CharacterHealthController>().GetIsDead() == false).ToList();

        if (_enemies.Count == 0) return;
        _targetDamagable = _enemies[0].GetComponent<IDamagable>();
        _target = _enemies[0].gameObject;
    }

    public bool HasAliveTargetInRange()
    {
        if (_targetDamagable != null && _targetDamagable.GetIsDead() == false)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}