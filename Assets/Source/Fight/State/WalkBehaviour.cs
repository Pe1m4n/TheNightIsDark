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
            _rigidbody2D.AddForce((_state.Destination - _rigidbody2D.position) * _state.Data.Speed, ForceMode2D.Force);
        }

        public override void Update()
        {
        }

        public override void OnFinish()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}