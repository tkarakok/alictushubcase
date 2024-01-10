
    using System;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHealthController : CharacterHealthController, IPlayerHealth
    {
        [SerializeField] private Slider _healthSlider;

        private Tween _healthBarTween;
        public override void Start()
        {
            base.Start();
            SetInitializeHealthBarDefaultValues();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(100);
            }
        }

        public void SetInitializeHealthBarDefaultValues()
        {
            _healthSlider.maxValue = _character.MaxHealth;
            _healthSlider.value = _healthSlider.maxValue;
        }

        public void SetHealthBarValue(int newValue)
        {
            _healthBarTween?.Kill();
            _healthBarTween = _healthSlider.DOValue(newValue, .2f).SetEase(Ease.Flash);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SetHealthBarValue(_character.CurrentHealth);
            if (GetIsDead())
            {
                GameManager.Instance.ChangeGameState(GameStates.LevelFailedState);
                EventManager.Instance.EventController.GetEvent<PlayerDeadEvent>().Data.Execute();
            }
            
        }
    }