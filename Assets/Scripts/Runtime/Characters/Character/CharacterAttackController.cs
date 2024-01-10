
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public abstract class CharacterAttackController : MonoBehaviour, ICharacterAttackController
    {
        [SerializeField] protected float _coolDownTimer;
        protected bool _isCoolDown;
        protected Transform _firePoint;
        protected Character _character;

        public virtual void Start()
        {
            _firePoint = GetComponentInChildren<FirePoint>().transform;
            _character = GetComponent<Character>();
        }

        public virtual void Update()
        {
        }


        public virtual void Attack()
        {
        }

        
    }