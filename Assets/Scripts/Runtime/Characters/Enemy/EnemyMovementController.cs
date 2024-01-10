using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMovementController : CharacterAIMovementController
{
    private EnemyAttackController _enemyAttackController;
    
    public override void Start()
    {
        base.Start();
        _enemyAttackController = GetComponent<EnemyAttackController>();
        SetTarget(GameManager.Instance.Player.transform);
    }

    public override void Update()
    {
        base.Update();
        if (_enemyAttackController.OnAttackAnim) return;
       
    }
}
