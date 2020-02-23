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
        public Vector2 Position => _rigidbody2D.position;
        private BulletState _bulletState;
        private Transform _bulletTransform;

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

            
            hit.DealDamage(_bulletState.Data.AttackData.Attack);
            if (_bulletState.Data.HitReaction != null)
            {
                var rot = _bulletTransform.rotation.eulerAngles;
                var direction = new Vector2(rot.x, rot.y);
                Instantiate(_bulletState.Data.HitReaction, _bulletState.HitPosition + direction.normalized, transform.rotation);
            }
            Destroy(gameObject);
        }

        public void SetTransform(Transform bulletTransform)
        {
            _bulletTransform = bulletTransform;
        }
    }
}