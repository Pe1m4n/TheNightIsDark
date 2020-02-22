using System.Collections.Generic;
using Fight.Health;
using Fight.Shooting;
using UnityEngine;

namespace Fight.State
{
    public class PlayerState
    {
        private Vector2 _position;
        public Dictionary<string, WeaponState> Weapons { get; } = new Dictionary<string, WeaponState>();
        public WeaponState CurrentWeapon { get; private set; }
        public HealthState HealthState { get; private set; }
        
        public InventoryState InventoryState { get; set; }
        
        public Vector2 Position { get; private set; }
        
        public PlayerState(PlayerData playerData)
        {
            HealthState = new HealthState(playerData.HealthData);
            InventoryState = new InventoryState(playerData.DefaultInventory);
            var weapon = new WeaponState(playerData.DefaultWeapon, InventoryState);
            weapon.Reload(true);
            Weapons.Add(playerData.DefaultWeapon.Name, weapon);
            CurrentWeapon = weapon;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }
    }
}