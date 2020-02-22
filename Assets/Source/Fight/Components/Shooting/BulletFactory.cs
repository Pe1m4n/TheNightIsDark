using System.Collections.Generic;
using Fight.State.SubStates;
using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    public class BulletFactory : PlaceholderFactory<BulletData, Vector3, Quaternion, BulletView>
    {
        private readonly DiContainer _container;
        private readonly Transform _transform;

        public BulletFactory(DiContainer container, Transform transform)
        {
            _container = container;
            _transform = transform;
        }

        public override BulletView Create(BulletData data, Vector3 position, Quaternion rotation)
        {
            var state = new BulletState(data);
            var bullet = _container.InstantiatePrefabForComponent<BulletView>(data.BulletPrefab, position, rotation, _transform, new List<object>(){state});
            bullet.SetForce(bullet.transform.up * data.Speed);
            return bullet;
        }
    }
}