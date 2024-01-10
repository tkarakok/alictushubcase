using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class CharacterAIMovementController : MonoBehaviour, ICharacterAIMovement
{
    protected CharacterHealthController _characterHealthController;

    protected NavMeshAgent _agent;
    protected Transform _target;

    public bool CanMove { get; private set; }
    protected CharacterState _characterState;

    public virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _characterHealthController = GetComponent<CharacterHealthController>();
        SetCharacterState(CharacterState.Run);
        SetCanMove(true);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (GameManager.Instance._gameStateController.GetCurrentGameState() != GameStates.InGameState) return;
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Stop()
    {
        if (_agent.isStopped) return;
        _agent.isStopped = true;
    }

    public void Move()
    {
        if (!CanMove) return;
        if (!_target && !_agent.isStopped) return;
        if (_characterState != CharacterState.Run) return;
        if (_characterHealthController.GetIsDead())
        {
            Stop();
            return;
        }
        
        _agent.SetDestination(_target.position);
    }


    public void SetCharacterState(CharacterState characterState)
    {
        _characterState = characterState;
    }

    public void SetCanMove(bool value)
    {
        CanMove = value;
    }
}