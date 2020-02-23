using Fight.Health;

namespace Fight.State
{
    public class HealthState
    {
        public HealthData Data { get; }
        public int CurrentHealth { get; set; }
        
        public HealthState(HealthData healthData)
        {
            Data = healthData;
            Reset();
        }

        public void DealDamage(int healthPoints)
        {
            CurrentHealth -= healthPoints;
        }

        public void Reset()
        {
            CurrentHealth = Data.TotalHealth;
        }
    }
}