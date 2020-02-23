using Fight.Health;
using Fight.State;

namespace Fight.Enemies
{
    public interface IBulletTarget
    {
         HealthState HealthState { get; }
    }
}