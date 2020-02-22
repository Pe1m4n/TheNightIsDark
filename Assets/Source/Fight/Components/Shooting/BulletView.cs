using Common;
using Fight.State.SubStates;
using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : ExtendedMonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private BulletState _bulletState;

        [Inject]
        public void SetUp(BulletState bulletState)
        {
            _bulletState = bulletState;
            _bulletState.ResetPosition(transform.position);
        }
        
        protected override void Awake()
        {
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetForce(Vector3 direction)
        {
            _rigidbody2D.AddForce(direction * _bulletState.Data.Speed, ForceMode2D.Impulse);
        }

        protected override void Update()
        {
            if (_bulletState.IsOutdated())
            {
                Destroy(gameObject);
            }
            var hit = _bulletState.CheckHit(transform.position);
            if (hit == null)
            {
                return;
            }

            hit.HealthState.DealDamage(_bulletState.Data.AttackData.Attack);
            Destroy(gameObject);
        }
    }
}