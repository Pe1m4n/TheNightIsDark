﻿namespace Fight.State
{
    public class InventoryState
    {
        public InventoryData Data { get; set; }
        
        public InventoryState(InventoryData data)
        {
            Data = data;
        }
        
        public int AmmoCount { get; set; }
        public int BarrelCount { get; set; }
        public int MineCount { get; set; }
        public int Dollars { get; set; }
    }
}