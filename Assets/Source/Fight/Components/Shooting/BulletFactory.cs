using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    public class BulletFactory : PlaceholderFactory<BulletData, Vector3, Quaternion, Bullet>
    {
        private readonly DiContainer _container;
        private readonly Transform _transform;

        public BulletFactory(DiContainer container, Transform transform)
        {
            _container = container;
            _transform = transform;
        }

        public override Bullet Create(BulletData data, Vector3 position, Quaternion rotation)
        {
            var bullet = _container.InstantiatePrefabForComponent<Bullet>(data.BulletPrefab, position, rotation, _transform, new List<object>(){data});
            bullet.SetForce(bullet.transform.up * data.Speed);
            return bullet;
        }
    }
}