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
            Behaviour = new WalkBehaviour(GetComponent<Rigidbody2D>(), State);
        }

        protected override void Update()
        {
            Behaviour?.Update();
            if (State.HealthState.CurrentHealth <= 0)
            {
                OnDeath();
            }

            if (State.ShouldBeginAttacking(transform.position, 2))
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