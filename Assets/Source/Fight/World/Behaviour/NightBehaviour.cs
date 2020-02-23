using Fight.Enemies;
using Fight.State;
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
        private readonly FightState _fightState;
        private int _spawned;

        private float _nextSpawn;
        
        public NightBehaviour(SpawnStrategy spawnStrategy, EnemyFactory enemyFactory,
            SpawnPointContainer spawnPointContainer, DayNightChangeData dayNightData,
            FightState fightState)
        {
            _spawnStrategy = spawnStrategy;
            _enemyFactory = enemyFactory;
            _spawnPointContainer = spawnPointContainer;
            _dayNightData = dayNightData;
            _fightState = fightState;
        }
        
        public override void Start()
        {
        }

        public override void Finish()
        {
            _nextSpawn = 0;
            _spawned = 0;
        }

        public override void Update()
        {
            if (!_spawnStrategy.spawnData.ContainsKey(_fightState.NightId))
            {
                return;
            }
            
            if (Time.time >= _nextSpawn && _spawned < _spawnStrategy.spawnData[_fightState.NightId].enemiesCount)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            if (!_spawnStrategy.spawnData.ContainsKey(_fightState.NightId))
            {
                return;
            }

            var spawnDelay = _dayNightData.NightSeconds /
                             _spawnStrategy.spawnData[_fightState.NightId].enemiesCount;
            var unitData = _spawnStrategy.GetUnitToSpawn();
            _enemyFactory.Create(unitData, _spawnPointContainer.GetRandomSpawnPoint());
            _nextSpawn = Time.time + spawnDelay;
            _spawned++;
        }
    }
}