using System;
using System.Collections.Generic;
using Common;
using Fight.Enemies;
using Sirenix.Serialization;
using UnityEngine;

namespace Fight
{
    public class SpawnStrategy : ExtendedScriptableObject
    {
        [Header("TODO: more complex settings")]
        [SerializeField] private EnemyData _enemy;

        [OdinSerialize] public Dictionary<int, SpawnData> spawnData = new Dictionary<int, SpawnData>();

        public EnemyData GetUnitToSpawn()
        {
            return _enemy;
        }
    }
    
    [Serializable]
    public class SpawnData
    {
        public int enemiesCount;
    }
}