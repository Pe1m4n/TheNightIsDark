using Common;
using Sirenix.Serialization;
using UnityEngine;

namespace Fight
{
    public class InventoryData : ExtendedScriptableObject
    {
        [OdinSerialize]
        public int AmmoCount { get; set; }
        [OdinSerialize]
        public int BarrelCount { get; set; }
        [OdinSerialize]
        public int MineCount { get; set; }
        [OdinSerialize]
        public int Dollars { get; set; }
    }
}