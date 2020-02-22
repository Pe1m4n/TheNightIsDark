using System;
using UnityEngine;

namespace Fight.Health
{
    [Serializable]
    public class HealthData
    {
        [SerializeField] private int _totalHealth;

        public int TotalHealth => _totalHealth;
    }
}