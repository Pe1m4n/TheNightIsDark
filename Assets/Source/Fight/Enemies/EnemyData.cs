using Common;
using Fight.Health;
using Sirenix.Serialization;
using UnityEngine;

namespace Fight.Enemies
{
    public class EnemyData : ExtendedScriptableObject
    {
        [OdinSerialize] public string Name { get; set; }
        [OdinSerialize] public HealthData HealthData { get; set; }
        [OdinSerialize] public AttackData AttackData { get; set; }
        [OdinSerialize] public EnemyView EnemyPrefab { get; set; }
    }
}