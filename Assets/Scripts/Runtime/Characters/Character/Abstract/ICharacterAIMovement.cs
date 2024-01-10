using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAIMovement
{
    void SetTarget(Transform target);
    void Stop();
    void Move();
    void SetCharacterState(CharacterState characterState);
    void SetCanMove(bool value);
}
