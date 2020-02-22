using UnityEngine;

namespace Fight.Shooting
{
    public class BulletData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private Bullet _bulletPrefab;

        public float Speed => _speed;
        public Bullet BulletPrefab => _bulletPrefab;
    }
}