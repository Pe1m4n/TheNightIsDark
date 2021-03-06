﻿using System.Collections.Generic;
using Fight.Gadgets;
using Fight.World;

namespace Fight.State
{
    public class FightState
    {
        public FightState(PlayerState playerState)
        {
            PlayerState = playerState;
        }
        
        public PlayerState PlayerState { get; private set; }
        public List<EnemyState> Enemies { get; } = new List<EnemyState>();
        public List<GadgetView> GadgetViews { get; } = new List<GadgetView>();
        
        public int NightId { get; set; }
        
        public WorldState WorldState { get; set; }

        public void Reset()
        {
            NightId = 0;
            foreach (var unit in Enemies)
            {
                unit.HealthState.DealDamage(3000);
            }
            Enemies.Clear();
            PlayerState.HealthState.Reset();;
            PlayerState.InventoryState.Reset();
            PlayerState.CurrentWeapon.Reset();
        }
    }
}