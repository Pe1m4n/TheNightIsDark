using Common;
using Common.InputSystem;
using Fight.Shooting;
using UnityEngine;
using Zenject;

namespace Fight
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : ExtendedMonoBehaviour
    {
        private IInputSystem _inputSystem;
        private RotationComponent _rotationComponent;
        private ShootingComponent _shootingComponent;
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
        }
    }
}