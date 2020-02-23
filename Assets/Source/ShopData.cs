using Common;
using Sirenix.Serialization;

namespace DefaultNamespace
{
    public class ShopData : ExtendedScriptableObject
    {
        [OdinSerialize] public ItemData AmmoShopData { get; set; }
        [OdinSerialize] public ItemData HealthShopData { get; set; }
        [OdinSerialize] public ItemData BarrelShopData { get; set; }
        [OdinSerialize] public ItemData MineShopData { get; set; }
    }
}