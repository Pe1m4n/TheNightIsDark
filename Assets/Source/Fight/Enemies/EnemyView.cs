﻿using Common;
using Common.AudioSystem;
using Fight.Health;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Enemies
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(Collider2D))]
    public class EnemyView : ExtendedMonoBehaviour, IBulletTarget
    {
        public EnemyState State { get; private set; }

        private AudioSource _audioSource;
        private EnemyBehaviour _behaviour;
        private RotationComponent _rotationComponent;
        private AudioTrack _deathSound;
        private PlayerState _playerState;
        private FightState _fightState;

        public EnemyBehaviour Behaviour
        {
            get => _behaviour;
            set
            {
                _behaviour?.OnFinish();
                _behaviour = value;
                _behaviour?.OnStart();
            }
        }
        
        [Inject]
        public void SetUp(EnemyState enemyState, PlayerState playerState, FightState fightState)
        {
            State = enemyState;
            var rb = GetComponent<Rigidbody2D>();
            _animationController = GetComponentInChildren<Animator>();
            
            _rotationComponent = new RotationComponent(rb);
            Behaviour = new WalkBehaviour(rb, State, _rotationComponent);
            _audioSource = GetComponent<AudioSource>();
            _playerState = playerState;
            _fightState = fightState;
        }

        private bool _attacking;
        private Animator _animationController;
        private HealthData _healthData;

        protected override void Update()
        {
            _rotationComponent.UpdateWithPosition(State.Destination);
            Behaviour?.Update();
            if (State.HealthState.CurrentHealth <= 0)
            {
                OnDeath();
                return;
            }

            if (_attacking)
            {
                return;
            }
            
            if (State.ShouldBeginAttacking(transform.position, State.Data.StopRadius))
            {
                BeginAttacking(); //don't fire me if you see this, i'm in panic mode
            }
        }

        private void BeginAttacking()
        {
            Behaviour = null;
            _animationController.SetBool("InAttack", true);
        }

        public void Attack()
        {
            _playerState.HealthState.DealDamage(State.AttackData.Attack);
        }

        private void OnDeath()
        {
            _playerState.InventoryState.Dollars += State.Data.Reward;
            _fightState.Enemies.Remove(State);
            Destroy(gameObject);
        }

        public HealthState HealthState => State.HealthState;
    }
}