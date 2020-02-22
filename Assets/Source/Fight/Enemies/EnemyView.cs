using Common;
using Fight.Health;
using Fight.State;
using UnityEngine;

namespace Fight.Enemies
{
    [RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(Collider2D))]
    public class EnemyView : ExtendedMonoBehaviour, IHealthStateContainer
    {
        public HealthState HealthState { get; set; }
    }
}