using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    public class ShootingComponent
    {
        private IFactory<BulletData, Vector3, Quaternion, Bullet> _bulletFactory;
        private readonly Transform _shootingTransform;
        private readonly AudioComponent _audioComponent;

        private Weapon _currentWeapon;

        public ShootingComponent(BulletFactory bulletFactory,
            Transform shootingTransform, AudioComponent audioComponent)
        {
            _bulletFactory = bulletFactory;
            _shootingTransform = shootingTransform;
            _audioComponent = audioComponent;
        }

        public void SetWeapon(Weapon weaponData)
        {
            _currentWeapon = weaponData;
        }

        public void Shoot()
        {
            if (_currentWeapon != null && _currentWeapon.Shoot())
            {
                _bulletFactory.Create(_currentWeapon.WeaponData.BulletData, _shootingTransform.position, _shootingTransform.rotation);
                _audioComponent.Play(_currentWeapon.WeaponData.ShootingSound);
                if (_currentWeapon.AmmoLoaded <= 0)
                {
                    _currentWeapon.Reload();
                }
            }
        }
    }
}