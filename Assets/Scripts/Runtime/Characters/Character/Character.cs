using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ICharacter
{
    public CharacterData CharacterData;
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get;  set; }

    public virtual void Awake()
    {
        SetCharacterData();
    }

    public void SetCharacterData()
    {
        MaxHealth = CharacterData.MaxHealth;
        CurrentHealth = MaxHealth;
    }
}
