using Fight.Health;

namespace Fight.State
{
    public class HealthState
    {
        public HealthData Data { get; }
        public int CurrentHealth { get; private set; }
        
        public HealthState(HealthData healthData)
        {
            Data = healthData;
            CurrentHealth = Data.TotalHealth;
        }

        public void DealDamage(int healthPoints)
        {
            CurrentHealth -= healthPoints;
        }
    }
}