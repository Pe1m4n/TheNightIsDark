using System;
using Common.InputSystem;
using DefaultNamespace;
using Fight;
using Fight.Enemies;
using Fight.Gadgets;
using Fight.Health;
using Fight.Shooting;
using Fight.State;
using Fight.World;
using Sirenix.Serialization;
using UI;
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
        [SerializeField] private TextComponent _textComponent;
        [SerializeField] private ShopManager _shopManager;
        [SerializeField] private BottomPanelHUD _bottomHud;
        [SerializeField] private ShopData _shopData;
        [SerializeField] private BarrelView _barrelPrefab;
        [SerializeField] private MineView _minePrefab;
        [SerializeField] private MineData _mineData;
        [SerializeField] private BarrelData _barrelData;
        [SerializeField] private BuildingCursorHolder _cursorHolder;

        public override void InstallBindings()
        {
            base.InstallBindings();
            
            BindCore();
            BindPlayerComponents();
            BindSpawning();

            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(playerView).AsSingle();
            Container.BindInterfacesAndSelfTo<ReactiveStateHolder>().AsSingle().NonLazy();
            Container.Bind<IObservable<FightState>>().FromResolveGetter<ReactiveStateHolder>(sh => sh.ObservableState)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<WorldStateChanger>().AsSingle().NonLazy();
            Container.Bind<TextComponent>().FromInstance(_textComponent).AsSingle();
            Container.BindInterfacesTo<ShopManager>().FromInstance(_shopManager).AsSingle();
            Container.BindInterfacesTo<BottomPanelHUD>().FromInstance(_bottomHud).AsSingle();
            Container.Bind<ShopData>().FromInstance(_shopData).AsSingle();
            Container.Bind<MineData>().FromInstance(_mineData).AsSingle();
            Container.Bind<BarrelData>().FromInstance(_barrelData).AsSingle();
            Container.Bind<BuildingCursorHolder>().FromInstance(_cursorHolder).AsSingle();
        }

        private void BindSpawning()
        {
            Container.BindFactory<EnemyData, SpawnPoint, EnemyView, EnemyFactory>()
                .WithFactoryArguments(_enemyContainerTransform);

            Container.Bind<SpawnPointContainer>().FromInstance(_spawnPointsContainer).AsSingle();
            Container.Bind<SpawnStrategy>().FromInstance(_spawnStrategy).AsSingle();
            Container.Bind<DayNightChangeData>().FromInstance(_dayNightChangeData).AsSingle();
            Container.BindFactory<BarrelData, Vector3, BarrelView, GadgetFactory<BarrelData, BarrelView>>().
                WithFactoryArguments(_barrelPrefab);
            Container.BindFactory<MineData, Vector3, MineView, GadgetFactory<MineData, MineView>>().
                WithFactoryArguments(_minePrefab);
            Container.Bind<DayBehaviour>().AsSingle();
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