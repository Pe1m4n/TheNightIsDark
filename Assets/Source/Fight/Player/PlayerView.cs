using Common;
using Common.InputSystem;
using Fight.Shooting;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
    public class PlayerView : ExtendedMonoBehaviour
    {
        private IInputSystem _inputSystem;
        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;
        private AudioComponent _audioComponent;
        private BulletFactory _bulletFactory;
        private PlayerState _playerState;
        [SerializeField] private LightFlashAnimation _flashAnimation;

        [Inject]
        public void SetUp(IInputSystem inputSystem, BulletFactory bulletFactory, PlayerState playerState)
        {
            _inputSystem = inputSystem;
            _bulletFactory = bulletFactory;
            _playerState = playerState;
            _playerState.SetPosition(transform.position);
        }

        private void Awake()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            _rotationComponent = new RotationComponent(rigidBody);
            _audioComponent = new AudioComponent(GetComponent<AudioSource>());
            _shootingComponent = new ShootingComponent(_bulletFactory, transform, _audioComponent, _playerState, _flashAnimation);
        }

        protected override void Update()
        {
            _rotationComponent.Update(_inputSystem.GetMousePosition());

            if (_inputSystem.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _shootingComponent.Shoot();
        }
    }
}