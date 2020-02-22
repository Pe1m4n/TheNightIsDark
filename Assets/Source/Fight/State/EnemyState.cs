using Fight.Enemies;
using Fight.Health;

namespace Fight.State
{
    public class EnemyState
    {
        public EnemyState(EnemyData enemyData, int id)
        {
            HealthState = new HealthState(enemyData.HealthData);
            AttackData = enemyData.AttackData;
            Id = id;
        }
        
        public HealthState HealthState { get; }
        public AttackData AttackData { get; }
        public int Id { get; }
    }
}