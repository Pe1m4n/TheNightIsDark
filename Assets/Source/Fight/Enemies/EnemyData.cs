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
        [OdinSerialize] public float Speed { get; set; }
        [OdinSerialize] public float StopRadius { get; set; }
        [OdinSerialize] public int Reward { get; set; }
    }
}