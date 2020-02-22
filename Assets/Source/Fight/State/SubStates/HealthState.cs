using Fight.Health;

namespace Fight.State
{
    public class HealthState
    {
        public HealthData Data { get; }
        public int CurrentHealth { get; }
        
        public HealthState(HealthData healthData)
        {
            Data = healthData;
            CurrentHealth = Data.TotalHealth;
        }
    }
}