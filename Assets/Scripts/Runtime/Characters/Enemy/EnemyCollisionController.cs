using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyCollisionController : CharacterCollisionController
{
    private EnemyAttackController _enemyAttackController;
    private EnemyMovementController _enemyMovementController;
    private EnemyAnimationController _enemyAnimationController;

    private void Start()
    {
        _enemyAttackController = GetComponentInParent<EnemyAttackController>();
        _enemyMovementController = GetComponentInParent<EnemyMovementController>();
        _enemyAnimationController = GetComponentInParent<EnemyAnimationController>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            _enemyAttackController.SetCanAttack(true);
            _enemyMovementController.SetCharacterState(CharacterState.Attack);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            _enemyAttackController.SetCanAttack(false);
            _enemyMovementController.SetCharacterState(CharacterState.Run);
            _enemyAnimationController.SetRun();
        }
    }
}
