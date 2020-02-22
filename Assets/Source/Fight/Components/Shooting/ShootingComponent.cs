using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    public class ShootingComponent
    {
        private IFactory<BulletData, Vector3, Quaternion, BulletView> _bulletFactory;
        private readonly Transform _shootingTransform;
        private readonly AudioComponent _audioComponent;
        private readonly PlayerState _playerState;

        public ShootingComponent(BulletFactory bulletFactory,
            Transform shootingTransform, AudioComponent audioComponent, PlayerState playerState)
        {
            _bulletFactory = bulletFactory;
            _shootingTransform = shootingTransform;
            _audioComponent = audioComponent;
            _playerState = playerState;
        }

        public void Shoot()
        {
            if (_playerState.CurrentWeapon != null && _playerState.CurrentWeapon.Shoot())
            {
                _bulletFactory.Create(_playerState.CurrentWeapon.WeaponData.BulletData, _shootingTransform.position, _shootingTransform.rotation);
                _audioComponent.Play(_playerState.CurrentWeapon.WeaponData.ShootingSound);
                if (_playerState.CurrentWeapon.AmmoLoaded <= 0)
                {
                    _playerState.CurrentWeapon.Reload();
                }
            }
        }
    }
}