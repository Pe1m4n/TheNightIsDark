namespace Fight.State
{
    public class InventoryState
    {
        public InventoryData Data { get; set; }
        
        public InventoryState(InventoryData data)
        {
            Data = data;

            Reset();
        }
        
        public int AmmoCount { get; set; }
        public int BarrelCount { get; set; }
        public int MineCount { get; set; }
        public int Dollars { get; set; }

        public void Reset()
        {
            AmmoCount = Data.AmmoCount;
            BarrelCount = Data.BarrelCount;
            MineCount = Data.MineCount;
            Dollars = Data.Dollars;
        }
    }
}