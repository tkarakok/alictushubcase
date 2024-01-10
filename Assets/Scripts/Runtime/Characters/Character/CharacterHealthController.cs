
    using System;
    using UnityEngine;

    public abstract class CharacterHealthController : MonoBehaviour, IDamagable, ICharacterHealthController
    {
        protected Character _character;
        private ICharacterAnim _characterAnim;
        public bool IsDead { get;  set; }

        public virtual void Start()
        {
            _character = GetComponent<Character>();
            _characterAnim = GetComponent<ICharacterAnim>();
        }

        public virtual void TakeDamage(int damage)
        {
            if (IsDead) return;
            _character.CurrentHealth -= damage;
            if (_character.CurrentHealth <= 0)
            {
                _characterAnim.Death();
                IsDead = true;
            }
        }

        public bool GetIsDead()
        {
            return IsDead;
        }

    }