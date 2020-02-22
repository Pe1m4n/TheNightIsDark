using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    public class ShootingComponent
    {
        private IFactory<BulletData, Vector3, Quaternion, Bullet> _bulletFactory;
        private readonly Transform _shootingTransform;

        public ShootingComponent(BulletFactory bulletFactory,
            Transform shootingTransform)
        {
            _bulletFactory = bulletFactory;
            _shootingTransform = shootingTransform;
        }

        public void Shoot(WeaponData weaponData)
        {
            _bulletFactory.Create(weaponData.BulletData, _shootingTransform.position, _shootingTransform.rotation);
        }
    }
}