using System.Collections.Generic;
using Fight.State;
using UnityEngine;
using Zenject;

namespace Fight.Enemies
{
    public class EnemyFactory : PlaceholderFactory<EnemyData, SpawnPoint, EnemyView>
    {
        private readonly DiContainer _container;
        private readonly FightState _fightState;
        private readonly Transform _enemyContainer;

        public EnemyFactory(DiContainer container, FightState fightState, Transform enemyContainer)
        {
            _container = container;
            _fightState = fightState;
            _enemyContainer = enemyContainer;
        }
        
        public override EnemyView Create(EnemyData enemyData, SpawnPoint spawnPoint)
        {
            var enemyState = new EnemyState(enemyData, _fightState.Enemies.Count);
            _fightState.Enemies.Add(enemyState);

            var enemyView = _container.InstantiatePrefabForComponent<EnemyView>(enemyData.EnemyPrefab,
                spawnPoint.transform.position, spawnPoint.transform.rotation,
                _enemyContainer, new List<object>(){enemyState});

            return enemyView;
        }
    }
}