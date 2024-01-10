using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionController : MonoBehaviour, ICharacterCollision
{
    public virtual void OnTriggerEnter(Collider other)
    {
    }

    public virtual void OnTriggerStay(Collider other)
    {
    }

    public virtual void OnTriggerExit(Collider other)
    {
    }
}
