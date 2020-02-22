using Common;
using Common.InputSystem;
using Fight.Shooting;
using UnityEngine;
using Zenject;

namespace Fight
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
    public class Player : ExtendedMonoBehaviour
    {
        private IInputSystem _inputSystem;
        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;
        private AudioComponent _audioComponent;
        [SerializeField] private WeaponData _weaponData;

        [Inject]
        public void SetUp(IInputSystem inputSystem, BulletFactory bulletFactory)
        {
            _inputSystem = inputSystem;
            _shootingComponent = new ShootingComponent(bulletFactory, transform);
        }

        private void Awake()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            _rotationComponent = new RotationComponent(rigidBody);
            _audioComponent = new AudioComponent(GetComponent<AudioSource>());
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
            _shootingComponent.Shoot(_weaponData);
            _audioComponent.Play(_weaponData.ShootingSound);
        }
    }
}