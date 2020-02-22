using Common.InputSystem;
using Fight;
using Fight.Health;
using Fight.Shooting;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FightSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private Transform _bulletPoolTransform;

        [SerializeField] private HealthData _playerHealthData;
        [SerializeField] private WeaponData _defaultWeapon;
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            BindCore();
            BindPlayerComponents();

            Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
        }

        private void BindPlayerComponents()
        {
            Container.BindFactory<BulletData, Vector3, Quaternion, BulletView, BulletFactory>()
                .WithFactoryArguments(_bulletPoolTransform);

        }

        private void BindCore()
        {
            Container.Bind<FightState>().AsSingle();
            Container.Bind<PlayerState>().AsSingle().WithArguments(_playerHealthData, _defaultWeapon);
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.BindInterfacesTo<UnityInputSystem>().AsSingle();
        }
    }
}