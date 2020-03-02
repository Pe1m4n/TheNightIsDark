using UnityEngine;

namespace Fight.State
{
    public class WalkBehaviour : EnemyBehaviour
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly EnemyState _state;

        public WalkBehaviour(Rigidbody2D rigidbody2D, EnemyState state)
        {
            _rigidbody2D = rigidbody2D;
            _state = state;
        }

        public override void OnStart()
        {
            var lookDir = _state.Destination - new Vector2(_rigidbody2D.position.x, _rigidbody2D.position.y);
            _rigidbody2D.velocity = lookDir.normalized * _state.Data.Speed;
        }

        public override void Update()
        {
            var lookDir = _state.Destination - new Vector2(_rigidbody2D.position.x, _rigidbody2D.position.y);
            _rigidbody2D.velocity = lookDir.normalized * _state.Data.Speed;
        }

        public override void OnFinish()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}