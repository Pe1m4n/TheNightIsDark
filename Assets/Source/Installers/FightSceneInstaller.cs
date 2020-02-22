using Common.InputSystem;
using Fight;
using Fight.Shooting;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FightSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Player _player;
        [SerializeField] private Transform _bulletPoolTransform;
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            BindCore();
            BindPlayerComponents();

            Container.Bind<Player>().FromInstance(_player).AsSingle();
        }

        private void BindPlayerComponents()
        {
            Container.BindFactory<BulletData, Vector3, Quaternion, Bullet, BulletFactory>()
                .WithFactoryArguments(_bulletPoolTransform);

        }

        private void BindCore()
        {
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.BindInterfacesTo<UnityInputSystem>().AsSingle();
        }
    }
}