using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class EnemyAttackController : CharacterAttackController, IEnemyAttack
{
    private EnemyAnimationController _enemyAnimationController;
    private EnemyMovementController _enemyMovementController;
    private EnemyHealthController _enemyHealthController;
    public bool CanAttack { get; private set; }
    public bool OnAttackAnim { get; private set; }

    public override void Start()
    {
        base.Start();
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
        _enemyMovementController = GetComponent<EnemyMovementController>();
        _enemyHealthController = GetComponent<EnemyHealthController>();
        SetOnAttackAnim(false);
        StartCoroutine(AttackCoroutine());
    }

    public override void Update()
    {
        base.Update();
        if (CanAttack && !_enemyHealthController.GetIsDead())
            transform.LookAt(new Vector3(GameManager.Instance.Player.transform.position.x, .5f, GameManager.Instance.Player.transform.position.z));
    }

    public override void Attack()
    {
        base.Attack();
        _enemyMovementController.SetCanMove(false);
        _enemyAnimationController.SetAttack();
    }

    public IEnumerator AttackCoroutine()
    {
        while (true)
        {
            if (CanAttack && !_enemyHealthController.GetIsDead() && GameManager.Instance._gameStateController.GetCurrentGameState() == GameStates.InGameState)
            {
                Attack();
                yield return new WaitForSeconds(_coolDownTimer);
            }else
                yield return null;
        }
    }

    public void SetCanAttack(bool param)
    {
        CanAttack = param;
    }

    public void SetOnAttackAnim(bool param)
    {
        OnAttackAnim = param;
    }

    public Transform GetFirePoint()
    {
        return _firePoint;
    }

    public int GetDamage()
    {
        return _character.CharacterData.Damage;
    }
}
