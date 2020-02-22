using Fight.Health;

namespace Fight.State
{
    public class EnemyState
    {
        public EnemyState(HealthData healthData, AttackData attackData)
        {
            HealthState = new HealthState(healthData);
            AttackData = attackData;
        }
        
        public HealthState HealthState { get; }
        public AttackData AttackData { get; }
    }
}