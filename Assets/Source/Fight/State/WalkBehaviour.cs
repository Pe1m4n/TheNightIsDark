﻿using UnityEngine;

namespace Fight.State
{
    public class WalkBehaviour : EnemyBehaviour
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly EnemyState _state;
        private readonly RotationComponent _rotationComponent;

        public WalkBehaviour(Rigidbody2D rigidbody2D, EnemyState state, RotationComponent rotationComponent)
        {
            _rigidbody2D = rigidbody2D;
            _state = state;
            _rotationComponent = rotationComponent;
            _rotationComponent.UpdateWithPosition(state.Destination);
        }

        public override void OnStart()
        {
            _rigidbody2D.velocity = _rotationComponent.UpVector * _state.Data.Speed;
        }

        public override void Update()
        {
            _rigidbody2D.velocity = _rotationComponent.UpVector * _state.Data.Speed;
        }

        public override void OnFinish()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}