using Fight.Enemies;
using Fight.Health;
using UnityEngine;

namespace Fight.State
{
    public class EnemyState
    {
        private readonly PlayerState _playerState;

        public EnemyState(EnemyData enemyData, PlayerState playerState, int id)
        {
            _playerState = playerState;
            HealthState = new HealthState(enemyData.HealthData);
            AttackData = enemyData.AttackData;
            Id = id;
            Data = enemyData;
        }
        
        public HealthState HealthState { get; }
        public AttackData AttackData { get; }
        public int Id { get; }
        public Vector2 Destination
        {
            get { return _playerState.Position; }
        }
        public EnemyData Data { get; }

        public bool ShouldBeginAttacking(Vector2 position, float radius)
        {
            if ((position - Destination).magnitude > 15)
            {
                return false;
            }
            
            var hits = Physics2D.OverlapCircleAll(position, radius, 9);
            if (hits == null)
            {
                return false;
            }

            foreach (var hit in hits)
            {
                var player = hit.GetComponent<PlayerView>();
                if (player == null)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}