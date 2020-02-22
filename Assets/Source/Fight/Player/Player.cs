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
        private BulletFactory _bulletFactory;
        [SerializeField] private WeaponData _weaponData;

        [Inject]
        public void SetUp(IInputSystem inputSystem, BulletFactory bulletFactory)
        {
            _inputSystem = inputSystem;
            _bulletFactory = bulletFactory;
        }

        private void Awake()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            _rotationComponent = new RotationComponent(rigidBody);
            _audioComponent = new AudioComponent(GetComponent<AudioSource>());
            _shootingComponent = new ShootingComponent(_bulletFactory, transform, _audioComponent);
            var weapon = new Weapon(_weaponData);
            weapon.Reload(true);
            _shootingComponent.SetWeapon(weapon); //TODO: normal weapon cycling
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