using Fight.Enemies;
using Fight.World;
using UnityEngine;

namespace Fight
{
    public class NightBehaviour : WorldBehaviourStrategy
    {
        private readonly SpawnStrategy _spawnStrategy;
        private readonly EnemyFactory _enemyFactory;
        private readonly SpawnPointContainer _spawnPointContainer;
        private readonly DayNightChangeData _dayNightData;
        private readonly WorldStateChanger _worldStateChanger;

        private float _nextSpawn;
        
        public NightBehaviour(SpawnStrategy spawnStrategy, EnemyFactory enemyFactory,
            SpawnPointContainer spawnPointContainer, DayNightChangeData dayNightData,
            WorldStateChanger worldStateChanger)
        {
            _spawnStrategy = spawnStrategy;
            _enemyFactory = enemyFactory;
            _spawnPointContainer = spawnPointContainer;
            _dayNightData = dayNightData;
            _worldStateChanger = worldStateChanger;
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
            if (!_spawnStrategy.spawnData.ContainsKey(_worldStateChanger.NightCount))
            {
                return;
            }

            var spawnDelay = _dayNightData.NightSeconds /
                             _spawnStrategy.spawnData[_worldStateChanger.NightCount].enemiesCount;
            var unitData = _spawnStrategy.GetUnitToSpawn();
            _enemyFactory.Create(unitData, _spawnPointContainer.GetRandomSpawnPoint());
            _nextSpawn = Time.time + spawnDelay;
        }
    }
}