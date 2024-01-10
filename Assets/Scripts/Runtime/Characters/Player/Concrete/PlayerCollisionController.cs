using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : CharacterCollisionController
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            other.GetComponent<PoolObject>().ResetObject();
            EventManager.Instance.EventController.GetEvent<CollectCoin>().Data.Execute();
            EventManager.Instance.EventController.GetEvent<UIInfoEvent>().Data.Execute();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GetComponent<IDamagable>().TakeDamage(100);
        }
        
    }
}
