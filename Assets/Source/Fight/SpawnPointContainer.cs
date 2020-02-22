using System.Collections.Generic;
using Fight.Enemies;
using UnityEngine;
using Zenject;

namespace Fight
{
    public class SpawnPointContainer : MonoBehaviour
    {
        public List<SpawnPoint> SpawnPoints { get; private set; }

        private void Awake()
        {
            SpawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
        }

        public SpawnPoint GetRandomSpawnPoint()
        {
            return SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        }
    }
}