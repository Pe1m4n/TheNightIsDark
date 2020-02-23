using Common;
using Sirenix.Serialization;

namespace Fight.World
{
    public class DayNightChangeData : ExtendedScriptableObject
    {
        [OdinSerialize] public float DaySeconds { get; set; }
        [OdinSerialize] public float NightSeconds { get; set;}
    }
}