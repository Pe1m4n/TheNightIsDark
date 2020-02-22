using Fight.Enemies;
using UnityEngine;

namespace Fight
{
    public class SpawnStrategy : ScriptableObject
    {
        [Header("TODO: more complex settings")]
        [SerializeField] private EnemyData _enemy;
        [SerializeField] private float _spawnRateSeconds;

        public float SpawnRateSeconds => _spawnRateSeconds;

        public EnemyData GetUnitToSpawn()
        {
            return _enemy;
        }
    }
}