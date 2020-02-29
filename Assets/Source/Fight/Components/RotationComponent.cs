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

        public void UpdateWithPosition(Vector2 desiredLookPosition)
        {
            var lookDirection = desiredLookPosition - _rigidbody2D.position;
            UpdateWithDirection(lookDirection);
        }

        public void UpdateWithDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _rigidbody2D.rotation = angle;
        }
        
    }
}