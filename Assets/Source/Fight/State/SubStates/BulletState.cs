using System;
using System.Collections.Generic;
using Fight.Enemies;
using Fight.Health;
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
        
        public Vector2 HitPosition { get; set; }
        
        public BulletState(BulletData data)
        {
            Data = data;
            _spawnTime = Time.time;
        }

        public void ResetPosition(Vector2 position)
        {
            _lastPosition = position;
        }

        public HealthState CheckHit(Vector2 position)
        {
            var hitsCount = Physics2D.OverlapAreaNonAlloc(_lastPosition, position, _hitColliders);

            _lastPosition = position;

            if (hitsCount == 0)
            {
                return null;
            }

            var enemyView = _hitColliders[0].GetComponent<IBulletTarget>();
            if (enemyView == null)
            {
                return null;
            }

            HitPosition = _hitColliders[0].transform.position;
            return enemyView.HealthState;
        }

        public bool IsOutdated()
        {
            return Time.time - _spawnTime >= 2;
        }
    }
}