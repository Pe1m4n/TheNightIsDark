using System;
using UnityEngine;

namespace Fight.Health
{
    [Serializable]
    public class AttackData
    {
        [SerializeField] private int _attack;

        public int Attack => _attack;
    }
}