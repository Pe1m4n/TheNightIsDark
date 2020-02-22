using Common;
using Fight.Health;
using Fight.Shooting;
using Sirenix.Serialization;

namespace Fight
{
    public class PlayerData : ExtendedScriptableObject
    {
        [OdinSerialize]
        private readonly HealthData _healthData;
        [OdinSerialize]
        private readonly WeaponData _defaultWeapon;

        public HealthData HealthData => _healthData;
        public WeaponData DefaultWeapon => _defaultWeapon;
    }
}