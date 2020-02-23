using Common;
using Fight.Health;
using Sirenix.Serialization;

namespace Fight.Gadgets
{
    public class BarrelData : ExtendedScriptableObject
    {
        [OdinSerialize] public HealthData HealthData { get; set; }

        [OdinSerialize] public AttackData AttackData { get; set; }

        [OdinSerialize] public float DamageRadius { get; set; }
    }
}