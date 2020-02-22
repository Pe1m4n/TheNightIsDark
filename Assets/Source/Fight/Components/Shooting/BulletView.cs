using Common;
using UnityEngine;
using Zenject;

namespace Fight.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : ExtendedMonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private BulletData _bulletData;

        [Inject]
        public void SetUp(BulletData bulletData)
        {
            _bulletData = bulletData;
        }
        
        protected override void Awake()
        {
            base.Awake();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetForce(Vector3 direction)
        {
            _rigidbody2D.AddForce(direction * _bulletData.Speed, ForceMode2D.Impulse);
        }
    }
}