using Common;
using Common.InputSystem;
using Fight.Shooting;
using Fight.State;
using Fight.World;
using UnityEngine;
using Zenject;

namespace Fight
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
    public class PlayerView : ExtendedMonoBehaviour, IWorldStateListener
    {
        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;
        private AudioComponent _audioComponent;
        private BulletFactory _bulletFactory;
        private PlayerState _playerState;
        [SerializeField] private LightFlashAnimation _flashAnimation;
        private FightState _state;
        private IPlayerInputController _playerInputController;

        [Inject]
        public void SetUp(BulletFactory bulletFactory, PlayerState playerState,
            FightState state, IPlayerInputController playerInputController)
        {
            _playerInputController = playerInputController;
            _bulletFactory = bulletFactory;
            _playerState = playerState;
            _playerState.SetPosition(transform.position);
            _state = state;
        }

        private void Awake()
        {
            Physics2D.autoSimulation = false;
            var rigidBody = GetComponent<Rigidbody2D>();
            _rotationComponent = new RotationComponent(rigidBody);
            _audioComponent = new AudioComponent(GetComponent<AudioSource>());
            _shootingComponent = new ShootingComponent(_bulletFactory, transform, _audioComponent, _playerState, _flashAnimation);
        }

        protected override void Update()
        {
            _rotationComponent.UpdateWithDirection(_playerInputController.GetLookDirection());
            Physics2D.Simulate(Time.deltaTime);
            if (_playerInputController.ShotKeyDown() && _state.WorldState == WorldState.Night)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _shootingComponent.Shoot();
        }

        public void OnWorldStateChanged(WorldState state)
        {
            gameObject.SetActive(state == WorldState.Night);
        }
    }
}