using Common;
using Fight.Health;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Enemies
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(Collider2D))]
    public class EnemyView : ExtendedMonoBehaviour
    {
        public EnemyState State { get; private set; }

        private EnemyBehaviour _behaviour;
        private RotationComponent _rotationComponent;

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
        public void SetUp(EnemyState enemyState)
        {
            State = enemyState;
            var rb = GetComponent<Rigidbody2D>();
            
            _rotationComponent = new RotationComponent(rb);
            Behaviour = new WalkBehaviour(rb, State, _rotationComponent);
        }

        private bool _attacking;
        protected override void Update()
        {
            _rotationComponent.Update(State.Destination);
            Behaviour?.Update();
            if (State.HealthState.CurrentHealth <= 0)
            {
                OnDeath();
            }

            if (_attacking)
            {
                return;
            }
            
            if (State.ShouldBeginAttacking(transform.position, 0.6f))
            {
                BeginAttacking(); //don't fire me if you see this, i'm in panic mode
            }
        }

        private void BeginAttacking()
        {
            Behaviour = null;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}