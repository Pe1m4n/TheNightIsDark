using System;
using System.Collections.Generic;
using Fight.Enemies;
using Fight.Shooting;
using UnityEngine;

namespace Fight.State.SubStates
{
    public class BulletState
    {
        public BulletData Data { get; }

        private Vector2 _lastPosition;
        private Collider2D[] _hitColliders = new Collider2D[1];

        private float _spawnTime;
        
        public BulletState(BulletData data)
        {
            Data = data;
            _spawnTime = Time.time;
        }

        public void ResetPosition(Vector2 position)
        {
            _lastPosition = position;
        }

        public EnemyState CheckHit(Vector2 position)
        {
            var hitsCount = Physics2D.OverlapAreaNonAlloc(_lastPosition, position, _hitColliders);

            _lastPosition = position;

            if (hitsCount == 0)
            {
                return null;
            }

            var enemyView = _hitColliders[0].GetComponent<EnemyView>();
            if (enemyView == null)
            {
                return null;
            }
            return enemyView.State;
        }

        public bool IsOutdated()
        {
            return Time.time - _spawnTime >= 2;
        }
    }
}