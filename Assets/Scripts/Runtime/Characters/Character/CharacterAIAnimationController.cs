using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAIAnimationController : CharacterAnimationController, ICharacterAiAnim
{
    public void SetRun()
    {
        _animator.SetTrigger("Run");
    }

    public void SetAttack()
    {
        _animator.SetTrigger("Attack");
    }
}
