using System;
using System.Threading.Tasks;
using Fight.State;
using UnityEngine;

namespace Fight.Shooting
{
    public class WeaponState
    {
        public int AmmoLoaded { get; private set; }
        public bool Reloading { get; private set; }
        public WeaponData WeaponData { get; }
        public InventoryState InventoryData { get; }

        public WeaponState(WeaponData data, InventoryState inventoryData)
        {
            WeaponData = data;
            InventoryData = inventoryData;
        }

        public void SetAmmo(int count)
        {
            AmmoLoaded = count;
        }

        private bool CanShoot()
        {
            return AmmoLoaded > 0 && !Reloading;
        }

        public bool Shoot()
        {
            if (!CanShoot())
            {
                return false;
            }
            AmmoLoaded--;
            return true;
        }

        public async void Reload(bool instant = false)
        {
            if (Reloading)
            {
                return;
            }

            if (!instant)
            {
                await Task.Delay(TimeSpan.FromSeconds(WeaponData.ReloadTime));
            }

            var countToLoad = Mathf.Clamp(InventoryData.AmmoCount, 0, WeaponData.BulletCapacity);
            InventoryData.AmmoCount -= countToLoad;
            AmmoLoaded = countToLoad;
            
            Reloading = false;
        }
    }
}