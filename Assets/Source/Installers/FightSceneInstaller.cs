using System;
using Common.InputSystem;
using Fight;
using Fight.Enemies;
using Fight.Health;
using Fight.Shooting;
using Fight.State;
using Fight.World;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FightSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private Transform _bulletPoolTransform;
        [SerializeField] private Transform _enemyContainerTransform;

        [SerializeField] private PlayerData _playerData;
        [SerializeField] private SpawnPointContainer _spawnPointsContainer;
        [SerializeField] private SpawnStrategy _spawnStrategy;
        [SerializeField] private IlluminationController _illuminationController;
        [SerializeField] private InventoryData _defaultInventory;
        [SerializeField] private DayNightChangeData _dayNightChangeData;
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            BindCore();
            BindPlayerComponents();
            BindSpawning();

            Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
            Container.BindInterfacesAndSelfTo<ReactiveStateHolder>().AsSingle().NonLazy();
            Container.Bind<IObservable<FightState>>().FromResolveGetter<ReactiveStateHolder>(sh => sh.ObservableState)
                .AsSingle();
        }

        private void BindSpawning()
        {
            Container.BindFactory<EnemyData, SpawnPoint, EnemyView, EnemyFactory>()
                .WithFactoryArguments(_enemyContainerTransform);

            Container.Bind<SpawnPointContainer>().FromInstance(_spawnPointsContainer).AsSingle();
            Container.Bind<SpawnStrategy>().FromInstance(_spawnStrategy).AsSingle();
            Container.Bind<DayNightChangeData>().FromInstance(_dayNightChangeData).AsSingle();
        }

        private void BindPlayerComponents()
        {
            Container.BindFactory<BulletData, Vector3, Quaternion, BulletView, BulletFactory>()
                .WithFactoryArguments(_bulletPoolTransform);

        }

        private void BindCore()
        {
            Container.Bind<FightState>().AsSingle();
            Container.Bind<PlayerState>().AsSingle().WithArguments(_playerData);
            Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
            Container.BindInterfacesTo<UnityInputSystem>().AsSingle();

            Container.Bind<IlluminationController>().FromInstance(_illuminationController).AsSingle();
            Container.BindInterfacesAndSelfTo<WorldController>().AsSingle().NonLazy();
            Container.Bind<NightBehaviour>().AsSingle().NonLazy();
        }
    }
}