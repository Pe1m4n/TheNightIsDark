using Fight.Enemies;
using UnityEngine;

namespace Fight
{
    public class NightBehaviour : WorldBehaviourStrategy
    {
        private readonly SpawnStrategy _spawnStrategy;
        private readonly EnemyFactory _enemyFactory;
        private readonly SpawnPointContainer _spawnPointContainer;

        private float _nextSpawn;
        
        public NightBehaviour(SpawnStrategy spawnStrategy, EnemyFactory enemyFactory, SpawnPointContainer spawnPointContainer)
        {
            _spawnStrategy = spawnStrategy;
            _enemyFactory = enemyFactory;
            _spawnPointContainer = spawnPointContainer;
        }
        
        public override void Start()
        {
        }

        public override void Finish()
        {
            _nextSpawn = 0;
        }

        public override void Update()
        {
            if (Time.time >= _nextSpawn)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            var unitData = _spawnStrategy.GetUnitToSpawn();
            _enemyFactory.Create(unitData, _spawnPointContainer.GetRandomSpawnPoint());
            Debug.LogWarning($"Spawning {unitData.Name}");
            _nextSpawn = Time.time + _spawnStrategy.SpawnRateSeconds;
        }
    }
}