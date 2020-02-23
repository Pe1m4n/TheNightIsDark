using Fight.Health;
using UnityEngine;

namespace Fight.Shooting
{
    public class BulletData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private AttackData _attackData;
        [SerializeField] private GameObject _hitReaction;

        public float Speed => _speed;
        public BulletView BulletPrefab => _bulletPrefab;
        public AttackData AttackData => _attackData;

        public GameObject HitReaction => _hitReaction;
    }
}