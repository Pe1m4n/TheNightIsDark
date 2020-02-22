using System.Collections.Generic;
using Fight.Health;
using Fight.Shooting;

namespace Fight.State
{
    public class PlayerState
    {
        public PlayerState(PlayerData playerData)
        {
            var weapon = new WeaponState(playerData.DefaultWeapon);
            weapon.Reload();
            Weapons.Add(playerData.DefaultWeapon.Name, weapon);
            CurrentWeapon = weapon;
            HealthState = new HealthState(playerData.HealthData);
        }
        
        public Dictionary<string, WeaponState> Weapons { get; } = new Dictionary<string, WeaponState>();
        public WeaponState CurrentWeapon { get; private set; }
        public HealthState HealthState { get; private set; }
    }
}