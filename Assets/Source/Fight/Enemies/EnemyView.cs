using Common;
using Fight.Health;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Enemies
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(Collider2D))]
    public class EnemyView : ExtendedMonoBehaviour, IHealthStateContainer
    {
        public EnemyState State { get; private set; }
        
        [Inject]
        public void SetUp(EnemyState enemyState)
        {
            State = enemyState;
        }
        public HealthState HealthState { get; set; }
    }
}