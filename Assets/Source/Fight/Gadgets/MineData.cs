using Common;
using Fight.Health;
using Sirenix.Serialization;

namespace Fight.Gadgets
{
    public class MineData : ExtendedScriptableObject
    {
        [OdinSerialize] public AttackData AttackData { get; set; }
        
        [OdinSerialize] public float TriggerRadius { get; set; }

        [OdinSerialize] public float DamageRadius { get; set; }
    }
}