using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    protected Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
    }
}
