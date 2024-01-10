using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerMovementController : MonoBehaviour
{
    #region References

    public Rigidbody Rigidbody { get; protected set; }

    #endregion

    private PlayerAnimationController _playerAnimationController;
    private CharacterAttackController _characterAttackController;

    public float MovementMultiplier;

    public float RotationMultiplier;


    #region Init Variables Rotation

    private Quaternion _currentRot;
    private Vector3 _targetRotAngle;

    #endregion

    protected virtual void Awake()
    {
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _characterAttackController = GetComponent<CharacterAttackController>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance._gameStateController.GetCurrentGameState() != GameStates.InGameState) return;
        Vector3 movement = new Vector3(InputManager.Instance.InputController.Joystick.Horizontal, 0,
            InputManager.Instance.InputController.Joystick.Vertical);
        movement.Normalize();
        ControllerLogic(movement);
        _playerAnimationController.SetMovementAnim(movement.normalized.magnitude);
    }

    protected void ControllerLogic(Vector3 movement)
    {
        CharacterMovement(movement);
        CharacterRotation();
    }

    private void CharacterMovement(Vector3 _direction)
    {
        Rigidbody.velocity = new Vector3(
            _direction.x * MovementMultiplier,
            Rigidbody.velocity.y,
            _direction.z * MovementMultiplier
        );
    }


    private void CharacterRotation()
    {
        if (!InputManager.Instance.InputController.Joystick.HasInput) return;
        _currentRot = transform.rotation;
        _targetRotAngle = new Vector3(InputManager.Instance.InputController.Joystick.Horizontal, Rigidbody.velocity.y,
                InputManager.Instance.InputController.Joystick.Vertical)
            .normalized;
        if (_targetRotAngle == Vector3.zero) _targetRotAngle = new Vector3(0, 0.001f, 0);
        Quaternion lookRotation = Quaternion.LookRotation(_targetRotAngle, Vector3.up);
        lookRotation.x = 0f;
        lookRotation.z = 0f;
        transform.rotation = Quaternion.Lerp(_currentRot, lookRotation,
            Time.fixedDeltaTime * RotationMultiplier);
    }


    public void ResetRigidbody()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
    }
}