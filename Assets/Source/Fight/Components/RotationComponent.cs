using UnityEngine;

namespace Fight
{
    public class RotationComponent
    {
        private readonly Rigidbody2D _rigidbody2D;

        public Vector3 UpVector
        {
            get => _rigidbody2D.transform.up;
        }

        public RotationComponent(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void Update(Vector2 desiredLookPosition)
        {
            var lookDirection = desiredLookPosition - _rigidbody2D.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = angle;
        }
    }
}