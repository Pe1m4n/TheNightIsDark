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
        private readonly PlayerState _playerState;

        public EnemyFactory(DiContainer container, FightState fightState, Transform enemyContainer, PlayerState playerState)
        {
            _container = container;
            _fightState = fightState;
            _enemyContainer = enemyContainer;
            _playerState = playerState;
        }
        
        public override EnemyView Create(EnemyData enemyData, SpawnPoint spawnPoint)
        {
            var enemyState = new EnemyState(enemyData, _playerState, _fightState.Enemies.Count);
            _fightState.Enemies.Add(enemyState);

            var enemyView = _container.InstantiatePrefabForComponent<EnemyView>(enemyData.EnemyPrefab,
                spawnPoint.transform.position, spawnPoint.transform.rotation,
                _enemyContainer, new List<object>(){enemyState});

            var tmpPos = enemyView.transform.position;
            tmpPos.z = 0;
            enemyView.transform.position = tmpPos;

            return enemyView;
        }
    }
}