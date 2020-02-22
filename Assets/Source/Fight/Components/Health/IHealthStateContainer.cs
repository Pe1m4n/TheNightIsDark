using Fight.State;

namespace Fight.Health
{
    public interface IHealthStateContainer
    {
        HealthState HealthState { get; }
    }
}